using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotiChallengeApp
{
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
            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.DictionaryFile = Directory.GetCurrentDirectory() + ENGLISH_DICTIONARY_PATH;
            wordDictionary.Initialize();

            Spelling spellingChecker = new Spelling();
            spellingChecker.Dictionary = wordDictionary;

            return spellingChecker;
        }
    }
}
