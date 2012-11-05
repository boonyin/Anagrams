using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Anagrams
{

    public partial class Form1 : Form
    {
        private Dictionary m_dictionary = new Dictionary(10);
        private string m_wavPath = Application.StartupPath + "\\Sounds\\";
        private int m_points = 0;
        private List<string> m_foundWords = new List<string>();
        private int m_remaining = 0;
        private GameConfig m_config = new GameConfig();
        private readonly string m_validAlphaCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private int m_lastWordTimePos = 0;


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // init the timer
            timerCountdown.Enabled = false;
            timerCountdown.Interval = 1000;

            // disable the word control
            this.textboxWord.Enabled = false;

            //init our labels
            this.m_points = 0;
            this.textboxWord.Text = "";
            this.textboxScrambled.Text = "";
            this.labelWordsFound.Text = "0";
            this.labelPoints.Text = "0";
            this.labelPossibleWords.Text = "";

            // init the progressbar
            smoothProgressBar.Minimum = 0;
            smoothProgressBar.Enabled = false;

			string msg = string.Format("{0} words were found in the\ndictionary. Prepare yourself.", m_dictionary.WordCount);
			MessageBox.Show(msg);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Fired when the user clicks the New Game button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Fired when the user hits return after typing in a word. The button 
        /// itself is on the form behind the list box so it's invisible to the 
        /// user, but still avaiable for use as the default button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // get the typed word
            string thisWord = this.textboxWord.Text;
            string soundFile = "";
            // if it's empty insult the user and return
            if (thisWord == "")
            {
                soundFile = "null_word.wav";
            }
            else
            {
                // look for the word in the appropriate wordlist object
                int foundIndex = m_dictionary.FindWord(thisWord);
                // found it!
                if (foundIndex >= 0)
                {
                    soundFile = "valid_word.wav";
                    // if the user hasn't already submitted the current word
                    if (!m_dictionary.IsDuplicateWord(foundIndex))
                    {

                        // add the word to the list
                        this.listboxWords.Items.Add(thisWord);
                        // mark the word as used
                        m_dictionary.MarkWordAsUsed(foundIndex);

                        // calculate the points and add them to our total
                        m_points += m_dictionary.WordPoints(foundIndex);
                        
					    // reward for using all of the letters
					    if (thisWord.Length == this.textboxScrambled.Text.Length)
					    {
						    // if the user submitted the actual scrambled word, that's cool
						    if (thisWord == m_dictionary.CurrentWord)
						    {
							    m_points += Anagrams.Properties.Settings.Default.AllLettersAward;
							    soundFile = "original_word.wav";
                                AddBonusTime(20);
                            }
						    // but if the came up with a completely different word, that's cooler
						    else
						    {
							    // this is an application setting so we don't need to use the 
							    // m_config object to retrieve the value (but we could if we 
							    // wanted to)
							    m_points += Anagrams.Properties.Settings.Default.AllLettersAward + 10;
                                soundFile = "allletters_word.wav";
                                AddBonusTime(30);
						    }
                        }

                        // if we are allowing bonus time
                        if (this.m_config.AwardBonusTime)
                        {
                            // calculate the bonus time
                            int bonusTime = (this.listboxWords.Items.Count % this.m_config.BonusWords == 0) ? this.m_config.BonusTime : 0;
                            if (bonusTime > 0)
                            {
                                AddBonusTime(bonusTime);
                                soundFile = "bonustime.wav";
                            }
                        }
                        // save the time at which the user submitted this word
                        this.m_lastWordTimePos = m_remaining;
                    }
                    else
                    {
                        // duplicate word - penalize the user
                        soundFile = "duplicate_word.wav";
                        this.m_points -= 2;
                    }
                }
                else
                {
                    // invalid word - penalize the user
                    soundFile = "invalid_word.wav";
                    this.m_points -= m_dictionary.WordPoints(thisWord);
                }
                // update our static labels
                this.labelPoints.Text = Convert.ToString(m_points);
                this.labelWordsFound.Text = Convert.ToString(this.listboxWords.Items.Count);
                this.textboxWord.Text = "";
                this.textboxWord.Focus();
            }
            PlayGameSound(soundFile);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Fired when the user types a letter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textboxWord_TextChanged(object sender, EventArgs e)
        {
            // only allow certain alphabetic characters.
            if (this.textboxWord.Text != "")
            {
                int charPos = this.textboxWord.Text.Length - 1;
                if (!m_validAlphaCharacters.Contains(this.textboxWord.Text.Substring(charPos, 1)))
                {
                    this.textboxWord.Text = this.textboxWord.Text.Remove(charPos, 1);
                    PlayGameSound("boop.wav");
                }
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Fired when the timer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            // calculate and display the time remaining
            TimeRemaining(false);
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Displays the configuration dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfigure_Click(object sender, EventArgs e)
        {
            Configure configForm = new Configure();
            configForm.Visible = false;
            if (configForm.ShowDialog() == DialogResult.OK)
            {
                // reload the configuration data
                m_config.Reload();
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //--------------------------------------------------------------------------------
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            EndGame();
        }

        /// <summary>
        /// Change the color of the text based on when the list is being updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listboxWords_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.  Create a new 
            // Brush and initialize to a Black colored brush by default.
            e.DrawBackground();
            Brush myBrush = Brushes.Red;
            string word = ((ListBox)sender).Items[e.Index].ToString();
            Font newFont = (Font)e.Font.Clone();

            if (m_remaining > 0)
            {
            }
            else
            {
                WordItem item = m_dictionary.GetPossibleWordItem(word);
                if (!item.Used)
                {
                    myBrush = Brushes.DarkGray;
                }
                else
                {
                    newFont = new Font(e.Font, FontStyle.Bold|FontStyle.Italic);
                }
            }
			if (word == m_dictionary.CurrentWord)
			{
				word += "**";
			}

            // Draw the current item text based on the current  Font and the custom brush settings.
            e.Graphics.DrawString(word, newFont, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle  around the selected item.
            e.DrawFocusRectangle();
        }

    }
}