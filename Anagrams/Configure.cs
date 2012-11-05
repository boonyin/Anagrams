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
    /// <summary>
    /// This class implements the configuration dialog.
    /// </summary>
    public partial class Configure : Form
    {
        // the path to the sound files
        private string m_wavPath = Application.StartupPath + "\\Sounds\\";
        // the settings object
        private GameConfig m_config = new GameConfig();
        // valid numeric characters for our data entry fields
        private readonly string m_validNumericCharacters = "1234567890";
        // integer value representing the current radio button selected for the letter pool mode
        private int m_radiogroupLetterPoolMode = -1;
        // integer value representing the current radio button selected for the timer mode
        private int m_radiogroupTimerMode = -1;

        public Configure()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the configuration data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Configure_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            //load data from user.config
            m_config.Reload();

            // letter pool
            switch (m_config.LetterPoolMode)
            {
                case 0:
                    this.radioLetterPoolRandom.Checked = true;
                    this.radioLetterPoolStatic.Checked = false;
                    break;
                case 1:
                    this.radioLetterPoolRandom.Checked = false;
                    this.radioLetterPoolStatic.Checked = true;
                    break;
            }
            this.m_radiogroupLetterPoolMode = m_config.LetterPoolMode;

            int letterCount = this.m_config.LetterCount;
            letterCount = Math.Min(Math.Max(letterCount, 6), 10);
            this.textboxLetterPool.Text = Convert.ToString(letterCount);

            // bonus time
            this.checkboxAwardBonusTime.Checked = this.m_config.AwardBonusTime;
            int bonusTime = this.m_config.BonusTime;
            bonusTime = Math.Min(Math.Max(bonusTime, 5), 60);
            this.textboxBonusTime.Text = Convert.ToString(bonusTime);
            int bonusWords = this.m_config.BonusWords;
            bonusWords = Math.Min(Math.Max(bonusWords, 5), 60);
            this.textboxBonusWords.Text = Convert.ToString(bonusWords);

            // Timing
            switch (m_config.TimerMode)
            {
                case 0:
                    this.radioTimerNone.Checked = true;
                    this.radioTimerStatic.Checked = false;
                    this.radioTimerPerLetter.Checked = false;
                    this.radioTimerBoth.Checked = false;
                    break;
                case 1:
                    this.radioTimerNone.Checked = false;
                    this.radioTimerStatic.Checked = true;
                    this.radioTimerPerLetter.Checked = false;
                    this.radioTimerBoth.Checked = false;
                    break;
                case 2:
                    this.radioTimerNone.Checked = false;
                    this.radioTimerStatic.Checked = false;
                    this.radioTimerPerLetter.Checked = true;
                    this.radioTimerBoth.Checked = false;
                    break;
                case 3:
                    this.radioTimerNone.Checked = false;
                    this.radioTimerStatic.Checked = false;
                    this.radioTimerPerLetter.Checked = false;
                    this.radioTimerBoth.Checked = true;
                    break;
            }
            this.m_radiogroupTimerMode = m_config.TimerMode;
            int secondsStatic = m_config.StaticSeconds;
            secondsStatic = Math.Min(Math.Max(secondsStatic, 10), 60);
            this.textboxTimerStatic.Text = Convert.ToString(secondsStatic);
            int secondsPerLetter = m_config.SecondsPerLetter;
            secondsPerLetter = Math.Min(Math.Max(secondsPerLetter, 3), 10);
            this.textboxSecondsPerLetter.Text = Convert.ToString(secondsPerLetter);

            // other settings
            checkboxPlaySounds.Checked = m_config.PlaySounds;
            checkboxAllowRepeats.Checked = m_config.AllowRepeatedWords;

            // update the enabled/disabled status of the controls
            UpdateControls();
        }

        /// <summary>
        /// Deterines if the OK button can be clicked. If certain radio buttons 
        /// are checked, there must be data in the appropriate text controls.
        /// </summary>
        /// <returns>True if the OK button can be clicked</returns>
        private bool CanClickOK()
        {
            bool canClick = ((this.radioLetterPoolRandom.Checked) || (this.radioLetterPoolStatic.Checked && this.textboxLetterPool.Text != ""));
            canClick &= ((!this.checkboxAwardBonusTime.Checked) || (this.checkboxAwardBonusTime.Checked && this.textboxBonusTime.Text != "" && this.textboxBonusWords.Text != ""));
            canClick &= ((this.radioTimerNone.Checked) ||
                         ((this.radioTimerStatic.Checked || this.radioTimerBoth.Checked) && (this.textboxTimerStatic.Text != "")) ||
                         ((this.radioTimerPerLetter.Checked || this.radioTimerBoth.Checked) && (this.textboxSecondsPerLetter.Text != "")));
            return canClick;
        }

        /// <summary>
        /// Plays the specified sound
        /// </summary>
        /// <param name="filename">The sound file to play</param>
        private void PlayGameSound(string filename)
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

        // makes sure the character that was typed was a valid numeric character
        private bool ValidNumber(TextBox textbox)
        {
            bool valid = true;
            if (textbox.Text != "")
            {
                int charPos = textbox.Text.Length - 1;
                if (!m_validNumericCharacters.Contains(textbox.Text.Substring(charPos, 1)))
                {
                    textbox.Text = textbox.Text.Remove(charPos, 1);
                    PlayGameSound("boop.wav");
                    valid = false;
                }
            }
            return valid;
        }

        /// <summary>
        /// Updates the enabled/disabled status of each control
        /// </summary>
        private void UpdateControls()
        {
            this.textboxLetterPool.Enabled = (this.radioLetterPoolStatic.Checked);
            this.textboxBonusTime.Enabled = (this.checkboxAwardBonusTime.Checked);
            this.textboxBonusWords.Enabled = (this.checkboxAwardBonusTime.Checked);
            this.textboxTimerStatic.Enabled = (this.radioTimerStatic.Checked || this.radioTimerBoth.Checked);
            this.textboxSecondsPerLetter.Enabled = (this.radioTimerPerLetter.Checked || this.radioTimerBoth.Checked);

            this.buttonOK.Enabled = CanClickOK();
        }

        /// <summary>
        /// Validates the text box values
        /// </summary>
        /// <returns>True is all values are valid</returns>
        private bool ValidData()
        {
            bool valid = true;
            int value = 0;
            if (this.radioLetterPoolStatic.Checked)
            {
                value = Convert.ToInt32(this.textboxLetterPool.Text);
                valid = (value >= Anagrams.Properties.Settings.Default.MinLetterPool &&
                         value <= Anagrams.Properties.Settings.Default.MaxLetterPool);
            }
            if (!valid)
            {
                MessageBox.Show("The letter pool value must be from 6-10.", "Data Error");
                this.textboxLetterPool.Focus();
                return valid;
            }

            if (this.checkboxAwardBonusTime.Checked)
            {
                value = Convert.ToInt32(this.textboxBonusTime.Text);
                valid = (value >= Anagrams.Properties.Settings.Default.MinBonusTime &&
                         value <= Anagrams.Properties.Settings.Default.MaxBonusTime);
            }
            if (!valid)
            {
                MessageBox.Show("The bonus time value must be from 10-60.", "Data Error");
                this.textboxBonusTime.Focus();
                return valid;
            }
            if (this.checkboxAwardBonusTime.Checked)
            {
                value = Convert.ToInt32(this.textboxBonusWords.Text);
                valid = (value >= Anagrams.Properties.Settings.Default.MinBonusWords &&
                         value <= Anagrams.Properties.Settings.Default.MaxBonusWords);
            }
            if (!valid)
            {
                MessageBox.Show("The bonus words value must be from 5-100.", "Data Error");
                this.textboxBonusWords.Focus();
                return valid;
            }
            if (this.radioTimerStatic.Checked)
            {
                value = Convert.ToInt32(this.textboxTimerStatic.Text);
                valid = (value >= Anagrams.Properties.Settings.Default.MinStaticSeconds &&
                         value <= Anagrams.Properties.Settings.Default.MaxStaticSeconds);
            }
            if (!valid)
            {
                MessageBox.Show("The static time value must be from 10-60.", "Data Error");
                this.textboxTimerStatic.Focus();
                return valid;
            }
            if (this.radioTimerPerLetter.Checked)
            {
                value = Convert.ToInt32(this.textboxSecondsPerLetter.Text);
                valid = (value >= Anagrams.Properties.Settings.Default.MinSecondsPerLetter &&
                         value <= Anagrams.Properties.Settings.Default.MaxSecondsPerLetter);
            }
            if (!valid)
            {
                MessageBox.Show("The seconds per letter value must be from 3-10.", "Data Error");
                this.textboxSecondsPerLetter.Focus();
                return valid;
            }
            return valid;
        }

        /// <summary>
        /// Updates the user.config file with the new settings
        /// </summary>
        private void UpdateConfig()
        {
            this.m_config.LetterPoolMode = this.m_radiogroupLetterPoolMode;
            this.m_config.LetterCount = Convert.ToInt32(this.textboxLetterPool.Text);
            this.m_config.AwardBonusTime = this.checkboxAwardBonusTime.Checked;
            this.m_config.BonusTime = Convert.ToInt32(this.textboxBonusTime.Text);
            this.m_config.BonusWords = Convert.ToInt32(this.textboxBonusWords.Text);
            this.m_config.TimerMode = this.m_radiogroupTimerMode;
            this.m_config.StaticSeconds = Convert.ToInt32(this.textboxTimerStatic.Text);
            this.m_config.SecondsPerLetter = Convert.ToInt32(this.textboxSecondsPerLetter.Text);
            this.m_config.PlaySounds = this.checkboxPlaySounds.Checked;
            this.m_config.AllowRepeatedWords = this.checkboxAllowRepeats.Checked;
            this.m_config.Write();
        }

        // resets all config items to their default values, and reloads the config
        private void buttonDefaultSettings_Click(object sender, EventArgs e)
        {
            this.m_config.SetToDefault();
            Reload();
        }

        /// <summary>
        /// Fired when the user clicks the OK button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (ValidData())
            {
                UpdateConfig();
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        /// <summary>
        /// Fired when the user clicks the Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textboxLetterPool_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxBonusTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxBonusWords_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxTimerStatic_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxSecondsPerLetter_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkboxPlaySounds_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkboxAllowRepeats_CheckedChanged(object sender, EventArgs e)
        {
        }

        //the following functon update their respective indicators and then update the controls
        private void radioLetterPoolRandom_CheckedChanged(object sender, EventArgs e)
        {
            this.m_radiogroupLetterPoolMode = 0;
            UpdateControls();
        }

        private void radioLetterPoolStatic_CheckedChanged(object sender, EventArgs e)
        {
            this.m_radiogroupLetterPoolMode = 1;
            UpdateControls();
        }

        private void checkboxAwardBonusTime_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void radioTimerNone_CheckedChanged(object sender, EventArgs e)
        {
            this.m_radiogroupTimerMode = 0;
            UpdateControls();
        }

        private void radioTimerStatic_CheckedChanged(object sender, EventArgs e)
        {
            this.m_radiogroupTimerMode = 1;
            UpdateControls();
        }

        private void radioTimerPerLetter_CheckedChanged(object sender, EventArgs e)
        {
            this.m_radiogroupTimerMode = 2;
            UpdateControls();
        }

        private void radioTimerBoth_CheckedChanged(object sender, EventArgs e)
        {
            this.m_radiogroupTimerMode = 3;
            UpdateControls();
        }

     }
}