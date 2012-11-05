using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Anagrams.Properties;

namespace Anagrams
{
    public class GameConfig
    {
        private int m_letterPoolMode; // 0=random (default), 1=static
        private int m_letterCount;    // if mode is static, value can be 6-10.
        private int m_bonusTime;
        private int m_bonusWords;
        private int m_minimumLettersPerWord;
        private int m_timerMode; //0=none, 1=static seconds, 2=seconds per letter, 3=both
        private int m_secondsPerLetter;
        private int m_staticSeconds;
        private bool m_playSounds;
        private bool m_allowWordRepeat;
        private bool m_showInstructions;
        private bool m_awardBonusTime;

        public int LetterPoolMode
        {
            get { return m_letterPoolMode;  }
            set { m_letterPoolMode = value; }
        }
        public int LetterCount
        {
            get { return m_letterCount; }
            set { m_letterCount = value; }
        }
        public bool AwardBonusTime
        {
            get { return m_awardBonusTime; }
            set { m_awardBonusTime = value; }
        }
        public int BonusTime
        {
            get { return m_bonusTime; }
            set { m_bonusTime = value; }
        }
        public int BonusWords
        {
            get { return m_bonusWords; }
            set { m_bonusWords = value; }
        }
        public int MinimumLettersPerWord
        {
            get { return m_minimumLettersPerWord; }
            set { m_minimumLettersPerWord = value; }
        }
        public int TimerMode
        {
            get { return m_timerMode;  }
            set { m_timerMode = value; }
        }
        public int SecondsPerLetter
        {
            get { return m_secondsPerLetter; }
            set { m_secondsPerLetter = value; }
        }
        public int StaticSeconds
        {
            get { return m_staticSeconds; }
            set { m_staticSeconds = value; }
        }
        public bool PlaySounds
        {
            get { return m_playSounds; }
            set { m_playSounds = value; }
        }
        public bool AllowRepeatedWords
        {
            get { return m_allowWordRepeat; }
            set { m_allowWordRepeat = value; }
        }
        public bool ShowInstructions
        {
            get { return m_showInstructions; }
            set { m_showInstructions = value; }
        }

        public GameConfig()
        {
            Reload();
        }

        public void Reload()
        {
            Anagrams.Properties.Settings.Default.Reload();
            this.LetterPoolMode = Anagrams.Properties.Settings.Default.LetterPoolMode;
            this.LetterCount = Anagrams.Properties.Settings.Default.LetterPoolCount;
            this.BonusTime = Anagrams.Properties.Settings.Default.BonusTime;
            this.BonusWords = Anagrams.Properties.Settings.Default.BonusWords;
            this.MinimumLettersPerWord = Anagrams.Properties.Settings.Default.MinimumLettersPerWord;
            this.TimerMode = Anagrams.Properties.Settings.Default.TimerMode;
            this.SecondsPerLetter = Anagrams.Properties.Settings.Default.SecondsPerLetter;
            this.StaticSeconds = Anagrams.Properties.Settings.Default.StaticSeconds;
            this.PlaySounds = Anagrams.Properties.Settings.Default.PlaySounds;
            this.AllowRepeatedWords = Anagrams.Properties.Settings.Default.AllowRepeatedWords;
            this.ShowInstructions = Anagrams.Properties.Settings.Default.ShowInstructions;
            this.m_awardBonusTime = Anagrams.Properties.Settings.Default.AwardBonusTime;
        }

        public void Write()
        {
            Anagrams.Properties.Settings.Default.LetterPoolMode = this.LetterPoolMode;
            Anagrams.Properties.Settings.Default.LetterPoolCount = this.LetterCount;
            Anagrams.Properties.Settings.Default.BonusTime = this.BonusTime;
            Anagrams.Properties.Settings.Default.BonusWords = this.BonusWords;
            Anagrams.Properties.Settings.Default.MinimumLettersPerWord = this.MinimumLettersPerWord;
            Anagrams.Properties.Settings.Default.TimerMode = this.TimerMode;
            Anagrams.Properties.Settings.Default.SecondsPerLetter = this.SecondsPerLetter;
            Anagrams.Properties.Settings.Default.StaticSeconds = this.StaticSeconds;
            Anagrams.Properties.Settings.Default.PlaySounds = this.PlaySounds;
            Anagrams.Properties.Settings.Default.AllowRepeatedWords = this.AllowRepeatedWords;
            Anagrams.Properties.Settings.Default.ShowInstructions = this.ShowInstructions;
            Anagrams.Properties.Settings.Default.AwardBonusTime = this.m_awardBonusTime;
            Anagrams.Properties.Settings.Default.Save();
        }

        public void SetToDefault()
        {
            Anagrams.Properties.Settings.Default.Reset();
            Anagrams.Properties.Settings.Default.Reload();
        }
    }
}
