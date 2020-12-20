using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotiChallengeApp
{
    public class WordTransformationService
    {
        private readonly ISpellChecker _spellChecker;

        public WordTransformationService(ISpellChecker spellChecker)
        {
            _spellChecker = spellChecker;
        }


        public string TransformWords (string startWord, string endWord)
        {
            return string.Empty;
        }
    }
}
