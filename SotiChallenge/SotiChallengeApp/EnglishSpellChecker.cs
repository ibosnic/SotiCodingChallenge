using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;
using System.IO;

namespace SotiChallengeApp
{
    /// <summary>
    /// This class does spelling checking for the english dictionary 
    /// </summary>
    public class EnglishSpellChecker : ISpellChecker
    {
        private Spelling _spellingChecker = null;
        private const string ENGLISH_DICTIONARY_PATH = "/dictionaryFiles/en-CA.dic";


        public bool IsWordSpelledCorrectly(string word)
        {
            if(_spellingChecker == null)
            {
                _spellingChecker = CreateSpellingChecker();
            }

            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            return _spellingChecker.TestWord(word);
        }

        private Spelling CreateSpellingChecker()
        {
            WordDictionary wordDictionary = new WordDictionary
            {
                DictionaryFile = Directory.GetCurrentDirectory() + ENGLISH_DICTIONARY_PATH
            };

            wordDictionary.Initialize();

            Spelling spellingChecker = new Spelling();
            spellingChecker.Dictionary = wordDictionary;

            return spellingChecker;
        }
    }
}
