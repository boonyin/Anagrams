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
        //--------------------------------------------------------------------------------
        /// <summary>
        /// Counts the number of words in the listbox that contain letterCount letters.
        /// </summary>
        /// <param name="letterCount">The number of letters that the word must contain in 
        /// order to be counted. This function should be called BEFORE posting the 
        /// remaining possible words to the listbox.</param>
        /// <returns>The number of words in the listbox that contain letterCount 
        /// letters.</returns>
        private int CountLetterWords(int letterCount)
        {
            int letterWords = 0;
            if (letterCount <= this.textboxScrambled.Text.Length)
            {
                for (int i = 0; i < this.listboxWords.Items.Count; i++)
                {
                    if (letterCount == this.listboxWords.Items[i].ToString().Length)
                    {
                        letterWords++;
                    }
                }
            }
            return letterWords;
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Posts the remaining possible words to the listbox.
        /// </summary>
        private void PostRemainingWords()
        {
			WordGroup possibleWords = m_dictionary.GetWordGroup(0);
            for (int i = 0; i < possibleWords.Count; i++)
            {
                WordItem item = possibleWords.GetWord(i);
				if (item != null && item.Text != "")
				{
					if (!this.listboxWords.Items.Contains(item.Text))
					{
						this.listboxWords.Items.Add(item.Text);
					}
				}
			}
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Plays the specified sound file. Sound files must be PCM for the 
        /// SoundPlayer to be able to play them.
        /// </summary>
        /// <param name="filename"></param>
        private void PlayGameSound(string filename)
        {
            // only play the sound file if the filename isn't blank and the 
            // configuration allows it
            if (this.m_config.PlaySounds && filename != "")
            {
                SoundPlayer sp = new SoundPlayer(m_wavPath + filename);
                try
                {
                    sp.Play();
                }
                catch (Exception e)
                {
                    if (e != null) { }
                }
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Calculates remaining time, and updates the progressbar. If the 
        /// user hasn't entered a word in 10 seconds, an annoying taunt 
        /// wav file is played.
        /// </summary>
        /// <param name="beginning"></param>
        private void TimeRemaining(bool beginning)
        {
            int interval = 0;

            // if we're not just starting out with this word scramble, we need to 
            // decrement the timer and maybe taunt the user
            if (!beginning)
            {
                // decrement the timer
                m_remaining -= 1;
                // update the progressbar value
                this.smoothProgressBar.Value -= 1;
                // see how long it's been since the user last submitted a word. If the 
                // difference bvetween the time remaining and the last time word was 
                // entered is evenly divisible by 10, the interval will be 0 (and it 
                // will be time to taunt the user)
                interval = (m_lastWordTimePos - m_remaining) % 10;
            }

            // if the game has expired, make an appropriate sound and update the game 
            // results panel.
            if (m_remaining == 0)
            {
                EndGame();
            }

            // update the progressbar display with the time remaining
            int seconds = m_remaining % 60;
            int minutes = (seconds == m_remaining) ? 0 : m_remaining / 60;
            this.smoothProgressBar.Text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Performs all end-of-game functionality, including calculating statistics, 
        /// stopping the timer, and posting unused words in the listbox.
        /// </summary>
        private void EndGame()
        {
            timerCountdown.Stop();
            m_remaining = 0;
            this.textboxWord.Text = "";
            this.textboxWord.Enabled = false;
            PlayGameSound("solve_word.wav");

            int wordsFound = this.listboxWords.Items.Count;
			int possible = Math.Max(1, m_dictionary.PossibleWordCount);
            double percentageFound = ((double)wordsFound / (double)possible) * 100.0;
            double pointsPerWord = ((double)m_points / (double)wordsFound);
            int[] letterWords = new int[m_dictionary.MaxGroups+1];
            letterWords.Initialize();
            for (int i = 3; i < letterWords.Length; i++)
            {
                letterWords[i] = CountLetterWords(i);
            }
            PostRemainingWords();
            StringBuilder statsFormatString = new StringBuilder("\n");
            statsFormatString.Append("% words found: {0:0.00}\n");
            statsFormatString.Append("Points per word: {1:0.00}\n");
            statsFormatString.Append("\n3-letter words: {2}\n");
            statsFormatString.Append("4-letter words: {3}\n");
            statsFormatString.Append("5-letter words: {4}\n");
            statsFormatString.Append("6-letter words: {5}\n");
            statsFormatString.Append("7-letter words: {6}\n");
            statsFormatString.Append("8-letter words: {7}\n");
            statsFormatString.Append("9-letter words: {8}\n");
            statsFormatString.Append("10-letter words: {9}\n");
            string gameStats = string.Format(statsFormatString.ToString(), 
                                             percentageFound,
                                             pointsPerWord,
                                             letterWords[3],
                                             letterWords[4],
                                             letterWords[5],
                                             letterWords[6],
                                             letterWords[7],
                                             letterWords[8],
                                             letterWords[9],
                                             letterWords[10]);

            labelGameStats.Text = gameStats;
            labelGameStats.Visible = true;
            groupboxStats.Visible = true;
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Starts a new game with a new word.
        /// </summary>
        private void StartNewGame()
        {
            PlayGameSound("newgame.wav");
            labelGameStats.Visible = false;
            groupboxStats.Visible = false;
            this.labelGameStats.Text = "";

            // determine how many letters the scrambled word will have
            int letterCount = 0;
            switch (this.m_config.LetterPoolMode)
            {
                case 0: // random
                    Random random = new Random();
                    letterCount = random.Next(6, 10);
                    break;
                case 1: // static (user-specified value from 6 to 10)
                    letterCount = this.m_config.LetterCount;
                    break;
            }

            // get a word, and find all possible words that can be found in that word
            string scramble = m_dictionary.GetRandomWord(letterCount, true);
			m_dictionary.FindPossibleWords(scramble);

            // track selected words if necessary
            //int remainingWords = words.Count;
            //int usedWords = words.CountUsed;
            //words.TrackRepeats = (!this.m_config.AllowRepeatedWords);

            // init our controls
            this.textboxScrambled.Text = scramble;
            this.textboxWord.MaxLength = scramble.Length;
            this.textboxWord.Focus();
            this.listboxWords.Items.Clear();
            this.labelWordsFound.Text = "0";

            // zero the points
            m_points = 0;
            this.labelPoints.Text = Convert.ToString(m_points);

            // count the possible words
            this.labelPossibleWords.Text = Convert.ToString(m_dictionary.PossibleWordCount);

            // clear out our found words
            m_foundWords.Clear();

            // set the time remaining
            switch (this.m_config.TimerMode)
            {
                case 0: // none
                    this.m_remaining = 0;
                    break;
                case 1: // static
                    this.m_remaining = this.m_config.StaticSeconds;
                    break;
                case 2: // seconds per letter
                    this.m_remaining = this.m_config.SecondsPerLetter * letterCount;
                    break;
                case 3: // both static and seconds per letter
                    this.m_remaining = this.m_config.StaticSeconds + this.m_config.SecondsPerLetter;
                    break;
                default:
                    this.m_remaining = 0;
                    break;
            }

            // initialize the taunt timeout
            m_lastWordTimePos = m_remaining;

            // if we have time remaining, update the time remaining controls, and start the timer
            if (m_remaining > 0)
            {
                TimeRemaining(true);
                timerCountdown.Enabled = true;
                smoothProgressBar.Maximum = m_remaining;
                smoothProgressBar.Value = m_remaining;
                smoothProgressBar.Visible = true;
                timerCountdown.Start();
            }
            else
            {
                // otherwise, disable the timer and hide the timer controls
                timerCountdown.Enabled = false;
                smoothProgressBar.Visible = false;
            }

            // allow the user to type in the "word" control
            this.textboxWord.Enabled = true;
            // set focus to it
            this.textboxWord.Focus();
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Adds bonus time to our timer and updates the progress bar
        /// </summary>
        /// <param name="bonusTime"></param>
        private void AddBonusTime(int bonusTime)
        {
            // add the time to our remaining time
            this.m_remaining += bonusTime;
            // reset the progressbar
            this.smoothProgressBar.Maximum = this.m_remaining;
            this.smoothProgressBar.Value = this.m_remaining;
            TimeRemaining(false);
        }
    }
}
