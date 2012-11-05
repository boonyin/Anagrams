using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Anagrams
{
    public class WordItem
    {
        public string m_text;
        public bool m_used;
        public WordItem(string text){m_text = text; m_used = false;}
    }

    public class WordsBase
    {
        protected string m_wordsPath;
        protected List<string> m_wordList = new List<string>();

        //--------------------------------------------------------------------------------
        public WordsBase()
        {
            m_wordsPath = AddBackslash(Application.StartupPath);
        }

        //--------------------------------------------------------------------------------
        protected string AddBackslash(string path)
        {
            if (path.LastIndexOf('\\') < path.Length - 1)
            {
                path += "\\";
            }
            return path;
        }

        //--------------------------------------------------------------------------------
        public void ClearList()
        {
            m_wordList.Clear();
        }


        //--------------------------------------------------------------------------------
        public string GetWord(int index)
        {
            string word = "";
            if (index >= 0 && index < m_wordList.Count)
            {
                word = m_wordList[index];
            }
            return word;
        }

    }

    public class Words : WordsBase
    {
        private List<string> m_usedWords = new List<string>();
        private int[] m_1stLetter = new int[26];
        //private int[] m_wordPoints = new int[26];
        private int[] m_wordPoints = { 1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10 };
        private bool m_trackUsedWords = true;
        private string m_fileName;
        private int m_lowEnd = -1;
        private int m_highEnd;
        private int m_letterCount = 0;

        public int Count
        {
            get { return m_wordList.Count; }
        }

        public int CountUsed
        {
            get { return m_usedWords.Count; }
        }

        public bool TrackRepeats
        {
            get { return m_trackUsedWords; }
            set { m_trackUsedWords = value; }
        }

        public int LetterCount
        {
            get { return m_letterCount; }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Loads the dictionary file based on the number of letters specified by 
        /// the calling function.
        /// </summary>
        /// <param name="letterCount"></param>
        public Words(int letterCount)
        {
            this.m_fileName = string.Format("{0}Words\\{1}.txt", m_wordsPath, letterCount);
            this.m_letterCount = letterCount;
            this.m_usedWords.Clear();
            this.m_wordList.Clear();

            //init the 1st letter index array to -1
            for (int i = 0; i < 26; i++)
            {
                this.m_1stLetter[i] = -1;
            }
            if (letterCount >= 3)
            {
                LoadFile();
            }
            this.m_highEnd = this.Count;
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Load the specified dictionary file
        /// </summary>
        /// <returns></returns>
        protected bool LoadFile()
        {
            bool success = false;
            try
            {
                FileStream stream = new FileStream(m_fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader reader = new StreamReader(stream);
                string words;
                while (!reader.EndOfStream)
                {
                    words = reader.ReadLine();
                    if (words.Length > 0)
                    {
                        string[] wordsplit = words.Split(' ');
                        string wordItem = "";
                        for (int i = 0; i < wordsplit.Length; i++)
                        {
                            wordItem = wordsplit[i].ToLower();
                            m_wordList.Add(wordItem);
                        }
                    }
                }
                success = true;
            }
            catch (Exception e)
            {
                if (e != null) { }
            }
            if (success)
            {
                m_wordList.Sort();
                FindLetterIndexes();
            }
            return success;
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Finds the starting position for each word by the first letter in 
        /// that word, and stores the results in a list.  This helps limit 
        /// the search for a correct word by allowing us to search a very 
        /// small subset of each letter-count group.
        /// </summary>
        protected void FindLetterIndexes()
        {
            int start = 0;
            for (int i = 0; i < 26; i++)
            {
                int intValue = 97 + i;
                string charValue = Convert.ToChar(intValue).ToString();

                if (m_wordList[start].StartsWith(charValue))
                {
                    m_1stLetter[i] = start;
                    for (int j = start; j < this.Count; j++)
                    {
                        if (!m_wordList[j].StartsWith(charValue))
                        {
                            start = j;
                            break;
                        }
                    }
                }
            }
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Finds the word that the user typed.
        /// </summary>
        /// <param name="wordToFind">The word submitted by the user.</param>
        /// <returns>True if the word was found</returns>
        public bool FindWord(string wordToFind)
        {
            wordToFind = wordToFind.ToLower();
            int count = m_wordList.Count;

            // limit the search to words that start with the first 
            // letter of the word we're looking for
            int letterIndex = Convert.ToInt16(wordToFind[0]) - 97;
            int start = m_1stLetter[letterIndex];
            int stop = (letterIndex == 25) ? count : m_1stLetter[letterIndex + 1];

            if (start >= 0)
            {
                for (int i = start; i < stop; i++)
                {
                    if (m_wordList[i] == wordToFind)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Scrambles the specified word by selectig a random letter from the 
        /// original word, and building a new "word" from those characters.
        /// </summary>
        /// <param name="oldWord"></param>
        /// <returns></returns>
        public string Scramble(string oldWord)
        {
            Random random = new Random();
            string newWord = "";
            int length = oldWord.Length;
            while (oldWord.Length > 0)
            {
                int index = random.Next(0, oldWord.Length);
                newWord += oldWord[index];
                oldWord = oldWord.Remove(index, 1);
            }
            return newWord;

        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Resets the word list to the specified percentage of original words. This is 
        /// only done when the user has elected to prevent duplicate useage of words, and 
        /// the user has used up all of the words in this word list.
        /// </summary>
        /// <param name="percent"></param>
        private void ResetWordList(int percent)
        {
            int resetCount = Convert.ToInt32(m_usedWords.Count * (percent*0.01));
            for (int i = 0; i < resetCount; i++)
            {
                m_wordList.Add(m_usedWords[0]);
                m_usedWords.RemoveAt(0);
            }
            m_wordList.Sort();
            FindLetterIndexes();
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a randomly selected word from the dictionary. The same 
        /// word should rarely (if ever) be selected more than once. To 
        /// reduce the chances of that,we trsack when a word at either of the 
        /// extreme ends of the dictionary are chosen.  This limits what 
        /// random number is generated to a small degeree and given repeated 
        /// play with the same word size, eventually reduces the possible 
        /// returns that can be generated by the random number generator.
        /// </summary>
        /// <param name="scrambled"></param>
        /// <returns></returns>
        public string GetRandomWord(bool scrambled)
        {
            if (m_wordList.Count == 0)
            {
            }

            Random random = new Random();
            // get the word we think we want to use
            int index = random.Next(m_lowEnd, m_highEnd);
            if (index == m_lowEnd + 1)
            {
                m_lowEnd++;
            }
            if (index == m_highEnd - 1)
            {
                m_highEnd--;
            }
            string randomWord = m_wordList[index];

            if (this.TrackRepeats)
            {
                m_usedWords.Add(randomWord);
                m_wordList.Remove(randomWord);
                FindLetterIndexes();
            }

            if (scrambled)
            {
                randomWord = Scramble(randomWord);
            }
            return randomWord;
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// For debugging only
        /// </summary>
        /// <param name="thisWord"></param>
        /// <returns></returns>
        public string ScrambleThisWord(string thisWord)
        {
            return Scramble(thisWord);
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Calculates the number of points that a word scores according to Scrabble 
        /// letter values.
        /// </summary>
        /// <param name="scoreWord"></param>
        /// <returns></returns>
        public int WordPoints(string scoreWord)
        {
            int points = 0;
            int count = scoreWord.Length;
            for (int i = 0; i < count; i++)
            {
                points += m_wordPoints[Convert.ToInt16(scoreWord[0]) - 97];
            }
            return points;
        }


        //--------------------------------------------------------------------------------
        // The idea is to search the specified word for an occurance of the 1st          
        // character of the word being compared.  If the character is found in the        
        // specified word, it is deleted from both words, thus eliminating the chance of  
        // finding too many matches for it in the specified word.  The first time we     
        // DON'T find a match, we know we can stop with the current compare word.        
        /// <summary>
        /// Finds all possible words that can be found in the specified string of 
        /// characters.
        /// </summary>
        /// <param name="thisWord"></param>
        /// <returns></returns>
        public int FindPossibleWords(string thisWord)
        {
            int wordsFound = 0;
            for (int j = 0; j < this.m_wordList.Count; j++)
            {
                string mainWord    = thisWord;
                string compareWord = m_wordList[j];
                bool   found       = true;
                
                while (found && compareWord.Length > 0)
                {
                    int index = mainWord.IndexOf(compareWord[0]);
                    if (index >= 0)
                    {
                        mainWord = mainWord.Remove(index, 1);
                        compareWord = compareWord.Remove(0, 1);
                    }
                    else
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    wordsFound += 1;
                }
            }
            return wordsFound;
        }

        //--------------------------------------------------------------------------------
        public string GetUsedWord(int index)
        {
            string word = "";
            if (index >= 0 && index < this.CountUsed)
            {
                word = m_usedWords[index];
            }
            return word;
        }
    }

    public class PossibleWords : WordsBase
    {
        private int m_letterCount = 0;
        private string m_baseWord;

        public List<string> WordList { get { return m_wordList; } }
        public int Count { get { return m_wordList.Count; } }

        public PossibleWords(string word)
        {
            m_letterCount = word.Length;
            m_baseWord = word;
            this.m_wordList.Clear();
        }

        public void FindWords(Words dictionary)
        {
            if (dictionary.LetterCount <= m_letterCount)
            {
                // check the used words
                for (int i = 0; i < dictionary.CountUsed; i++)
                {
                    string baseWord = m_baseWord;
                    string compareWord = dictionary.GetUsedWord(i);
                    bool found = true;
                    while (found && compareWord.Length > 0)
                    {
                        int index = baseWord.IndexOf(compareWord[0]);
                        if (index >= 0)
                        {
                            baseWord = baseWord.Remove(index, 1);
                            compareWord = compareWord.Remove(0, 1);
                        }
                        else
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        string word = dictionary.GetWord(i);
                        m_wordList.Add(word);
                    }
                }


                // check the unused words
                for (int i = 0; i < dictionary.Count; i++)
                {
                    string baseWord = m_baseWord;
                    string compareWord = dictionary.GetWord(i);
                    bool found = true;
                    while (found && compareWord.Length > 0)
                    {
                        int index = baseWord.IndexOf(compareWord[0]);
                        if (index >= 0)
                        {
                            baseWord = baseWord.Remove(index, 1);
                            compareWord = compareWord.Remove(0, 1);
                        }
                        else
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        string word = dictionary.GetWord(i);
                        m_wordList.Add(word);
                    }
                }

            }
        }

        //--------------------------------------------------------------------------------
        // The idea is to search the specified word for an occurance of the 1st          
        // character of the word being compared.  If the character is found in the        
        // specified word, it is deleted from both words, thus eliminating the chance of  
        // finding too many matches for it in the specified word.  The first time we     
        // DON'T find a match, we know we can stop with the current compare word.        
        /// <summary>
        /// Finds all possible words that can be found in the specified string of 
        /// characters.
        /// </summary>
        /// <param name="thisWord"></param>
        /// <returns></returns>
        public int FindPossibleWords(string thisWord)
        {
            int wordsFound = 0;
            for (int j = 0; j < this.m_wordList.Count; j++)
            {
                string mainWord = thisWord;
                string compareWord = m_wordList[j];
                bool found = true;

                while (found && compareWord.Length > 0)
                {
                    int index = mainWord.IndexOf(compareWord[0]);
                    if (index >= 0)
                    {
                        mainWord = mainWord.Remove(index, 1);
                        compareWord = compareWord.Remove(0, 1);
                    }
                    else
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    wordsFound += 1;
                }
            }
            return wordsFound;
        }

    }

    
    /////////////////////////////////
    public class WordsBase2
    {
        protected string m_wordsPath;
        protected List<WordItem> m_wordList = new List<WordItem>();

        //--------------------------------------------------------------------------------
        public WordsBase2()
        {
            m_wordsPath = AddBackslash(Application.StartupPath);
        }

        //--------------------------------------------------------------------------------
        protected string AddBackslash(string path)
        {
            if (path.LastIndexOf('\\') < path.Length - 1)
            {
                path += "\\";
            }
            return path;
        }

        //--------------------------------------------------------------------------------
        public void ClearList()
        {
            m_wordList.Clear();
        }

        //--------------------------------------------------------------------------------
        public WordItem GetWordItem(int index)
        {
            WordItem item = null;
            if (index >= 0 && index < m_wordList.Count)
            {
                item = m_wordList[index];
            }
            return item;
        }
    }

    public class Words2 : WordsBase2
    {
        private List<WordItem> m_usedWords = new List<WordItem>();
        private int[] m_1stLetter = new int[26];
        //private int[] m_wordPoints = new int[26];
        private int[] m_wordPoints = { 1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10 };
        private bool m_trackUsedWords = true;
        private string m_fileName;
        private int m_lowEnd = -1;
        private int m_highEnd;
        private int m_letterCount = 0;

        public int Count
        {
            get { return m_wordList.Count; }
        }

        public int CountUsed
        {
            get { return CountUsedWords(); }
        }

        public bool TrackRepeats
        {
            get { return m_trackUsedWords; }
            set { m_trackUsedWords = value; }
        }

        public int LetterCount
        {
            get { return m_letterCount; }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Loads the dictionary file based on the number of letters specified by 
        /// the calling function.
        /// </summary>
        /// <param name="letterCount"></param>
        public Words2(int letterCount)
        {
            this.m_fileName = string.Format("{0}Words\\{1}.txt", m_wordsPath, letterCount);
            this.m_letterCount = letterCount;
            this.m_usedWords.Clear();
            this.m_wordList.Clear();

            //init the 1st letter index array to -1
            for (int i = 0; i < 26; i++)
            {
                this.m_1stLetter[i] = -1;
            }
            if (letterCount >= 3)
            {
                LoadFile();
            }
            this.m_highEnd = this.Count;
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Load the specified dictionary file
        /// </summary>
        /// <returns></returns>
        protected bool LoadFile()
        {
            bool success = false;
            try
            {
                FileStream stream = new FileStream(m_fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader reader = new StreamReader(stream);
                string words;
                while (!reader.EndOfStream)
                {
                    words = reader.ReadLine();
                    if (words.Length > 0)
                    {
                        string[] wordsplit = words.Split(' ');
                        for (int i = 0; i < wordsplit.Length; i++)
                        {
                            WordItem item = new WordItem(wordsplit[i].ToLower());
                            m_wordList.Add(item);
                        }
                    }
                }
                success = true;
            }
            catch (Exception e)
            {
                if (e != null) { }
            }
            if (success)
            {
                m_wordList.Sort();
                FindLetterIndexes();
            }
            return success;
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Finds the starting position for each word by the first letter in 
        /// that word, and stores the results in a list.  This helps limit 
        /// the search for a correct word by allowing us to search a very 
        /// small subset of each letter-count group.
        /// </summary>
        protected void FindLetterIndexes()
        {
            int start = 0;
            for (int i = 0; i < 26; i++)
            {
                int intValue = 97 + i;
                string charValue = Convert.ToChar(intValue).ToString();

                if (m_wordList[start].m_text.StartsWith(charValue))
                {
                    m_1stLetter[i] = start;
                    for (int j = start; j < this.Count; j++)
                    {
                        if (!m_wordList[j].m_text.StartsWith(charValue))
                        {
                            start = j;
                            break;
                        }
                    }
                }
            }
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Finds the word that the user typed.
        /// </summary>
        /// <param name="wordToFind">The word submitted by the user.</param>
        /// <returns>True if the word was found</returns>
        public bool FindWord(string wordToFind)
        {
            wordToFind = wordToFind.ToLower();
            int count = m_wordList.Count;

            // limit the search to words that start with the first 
            // letter of the word we're looking for
            int letterIndex = Convert.ToInt16(wordToFind[0]) - 97;
            int start = m_1stLetter[letterIndex];
            int stop = (letterIndex == 25) ? count : m_1stLetter[letterIndex + 1];

            if (start >= 0)
            {
                for (int i = start; i < stop; i++)
                {
                    if (m_wordList[i].m_text == wordToFind)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// Scrambles the specified word by selecting a random letter from the 
        /// original word, and building a new "word" from those characters.
        /// </summary>
        /// <param name="oldWord"></param>
        /// <returns></returns>
        public string Scramble(string oldWord)
        {
            Random random = new Random();
            string newWord = "";
            int length = oldWord.Length;
            while (oldWord.Length > 0)
            {
                int index = random.Next(0, oldWord.Length);
                newWord += oldWord[index];
                oldWord = oldWord.Remove(index, 1);
            }
            return newWord;

        }

        //--------------------------------------------------------------------------------
        private int CountUsedWords()
        {
            int used = 0;
            for (int i = 0; i < m_wordList.Count; i++)
            {
                if (m_wordList[i].m_used)
                {
                    used++;
                }
            }
            return used;
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Resets the word list to the specified percentage of original words. This is 
        /// only done when the user has elected to prevent duplicate useage of words, and 
        /// the user has used up all of the words in this word list.
        /// </summary>
        /// <param name="percent"></param>
        private void ResetWordList(int percent)
        {
            int reset = 0;
            int resetCount = Convert.ToInt32(CountUsedWords() * (percent*0.01));
            for (int i = 0; i < m_wordList.Count; i++)
            {
                if (m_wordList[i].m_used)
                {
                    m_wordList[i].m_used = false;
                    reset++;
                }
                //m_usedWords.RemoveAt(0);
            }
            //m_wordList.Sort();
            //FindLetterIndexes();
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a randomly selected word from the dictionary. The same 
        /// word should rarely (if ever) be selected more than once. To 
        /// reduce the chances of that,we trsack when a word at either of the 
        /// extreme ends of the dictionary are chosen.  This limits what 
        /// random number is generated to a small degeree and given repeated 
        /// play with the same word size, eventually reduces the possible 
        /// returns that can be generated by the random number generator.
        /// </summary>
        /// <param name="scrambled"></param>
        /// <returns></returns>
        public string GetRandomWord(bool scrambled)
        {
            if (m_wordList.Count == 0)
            {
            }

            Random random = new Random();
            // get the word we think we want to use
            int index = random.Next(m_lowEnd, m_highEnd);
            if (index == m_lowEnd + 1)
            {
                m_lowEnd++;
            }
            if (index == m_highEnd - 1)
            {
                m_highEnd--;
            }
            string randomWord = m_wordList[index].m_text;

            if (this.TrackRepeats)
            {
                //m_usedWords.Add(randomWord);
                //m_wordList.Remove(randomWord);
                //FindLetterIndexes();
                m_wordList[index].m_used = true;
            }

            if (scrambled)
            {
                randomWord = Scramble(randomWord);
            }
            return randomWord;
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// For debugging only
        /// </summary>
        /// <param name="thisWord"></param>
        /// <returns></returns>
        public string ScrambleThisWord(string thisWord)
        {
            return Scramble(thisWord);
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Calculates the number of points that a word scores according to Scrabble 
        /// letter values.
        /// </summary>
        /// <param name="scoreWord"></param>
        /// <returns></returns>
        public int WordPoints(string scoreWord)
        {
            int points = 0;
            int count = scoreWord.Length;
            for (int i = 0; i < count; i++)
            {
                points += m_wordPoints[Convert.ToInt16(scoreWord[0]) - 97];
            }
            return points;
        }


        //--------------------------------------------------------------------------------
        // The idea is to search the specified word for an occurance of the 1st          
        // character of the word being compared.  If the character is found in the        
        // specified word, it is deleted from both words, thus eliminating the chance of  
        // finding too many matches for it in the specified word.  The first time we     
        // DON'T find a match, we know we can stop with the current compare word.        
        /// <summary>
        /// Finds all possible words that can be found in the specified string of 
        /// characters.
        /// </summary>
        /// <param name="thisWord"></param>
        /// <returns></returns>
        public int FindPossibleWords(string thisWord)
        {
            int wordsFound = 0;
            for (int j = 0; j < this.m_wordList.Count; j++)
            {
                string mainWord    = thisWord;
                string compareWord = m_wordList[j].m_text;
                bool   found       = true;
                
                while (found && compareWord.Length > 0)
                {
                    int index = mainWord.IndexOf(compareWord[0]);
                    if (index >= 0)
                    {
                        mainWord = mainWord.Remove(index, 1);
                        compareWord = compareWord.Remove(0, 1);
                    }
                    else
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    wordsFound += 1;
                }
            }
            return wordsFound;
        }

        ////--------------------------------------------------------------------------------
        //public string GetUsedWord(int index)
        //{
        //    string word = "";
        //    if (index >= 0 && index < this.CountUsed)
        //    {
        //        word = m_usedWords[index];
        //    }
        //    return word;
        //}
    }

    public class PossibleWords2 : WordsBase2
    {
        private int m_letterCount = 0;
        private string m_baseWord;

        public List<WordItem> WordList { get { return m_wordList; } }
        public int Count { get { return m_wordList.Count; } }

        public PossibleWords2(string word)
        {
            m_letterCount = word.Length;
            m_baseWord = word;
            this.m_wordList.Clear();
        }

        public void FindWords(Words2 dictionary)
        {
            if (dictionary.LetterCount <= m_letterCount)
            {
                // check the unused words
                for (int i = 0; i < dictionary.Count; i++)
                {
                    string baseWord = m_baseWord;
                    WordItem item = dictionary.GetWordItem(i);
                    string compareWord = item.m_text;
                    bool found = true;
                    while (found && compareWord.Length > 0)
                    {
                        int index = baseWord.IndexOf(compareWord[0]);
                        if (index >= 0)
                        {
                            baseWord = baseWord.Remove(index, 1);
                            compareWord = compareWord.Remove(0, 1);
                        }
                        else
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        m_wordList.Add(item);
                    }
                }

            }
        }

        //--------------------------------------------------------------------------------
        // The idea is to search the specified word for an occurance of the 1st          
        // character of the word being compared.  If the character is found in the        
        // specified word, it is deleted from both words, thus eliminating the chance of  
        // finding too many matches for it in the specified word.  The first time we     
        // DON'T find a match, we know we can stop with the current compare word.        
        /// <summary>
        /// Finds all possible words that can be found in the specified string of 
        /// characters.
        /// </summary>
        /// <param name="thisWord"></param>
        /// <returns></returns>
        public int FindPossibleWords(string thisWord)
        {
            int wordsFound = 0;
            for (int j = 0; j < this.m_wordList.Count; j++)
            {
                string baseWord = m_baseWord;
                WordItem item = m_wordList.GetWordItem(i);
                string compareWord = item.m_text;
                bool found = true;
                while (found && compareWord.Length > 0)
                {
                    int index = baseWord.IndexOf(compareWord[0]);
                    if (index >= 0)
                    {
                        baseWord = baseWord.Remove(index, 1);
                        compareWord = compareWord.Remove(0, 1);
                    }
                    else
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    wordsFound += 1;
                }
            }
            return wordsFound;
        }

    }
}

