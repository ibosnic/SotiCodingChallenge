using System.Collections.Generic;
using System.Linq;

namespace SotiChallengeApp
{
    /// <summary>
    ///   The class to implement the solution in.
    /// </summary>
    public class WordTransformationService
    {
        private readonly ISpellChecker _spellChecker;
        private const string WORDS_EMPTY_TEXT = "Start Word or End Word is empty.";
        private const string NOT_SAME_LENGTH_TEXT= "Start Word and End Word are not the same length.";
        private const string WORDS_NOT_TRANSFORMED_TEXT = "Words cannot be tranformed.";
        private const string INVALID_ENGLISH_WORDS_TEXT = "Start or End Word not valid english words.";

        public WordTransformationService(ISpellChecker spellChecker)
        {
            _spellChecker = spellChecker;
        }

        /// <summary>
        /// Tranforms the start word into the end word keeping track of all the steps. 
        /// </summary>
        public string TransformWords (string startWord, string endWord)
        {
            if(string.IsNullOrEmpty(startWord) || string.IsNullOrEmpty(endWord))
            {
                return WORDS_EMPTY_TEXT;
            }

            if(startWord.Length != endWord.Length)
            {
                return NOT_SAME_LENGTH_TEXT;
            }

            if( !_spellChecker.IsWordSpelledCorrectly(startWord) || !_spellChecker.IsWordSpelledCorrectly(endWord))
            {
                return INVALID_ENGLISH_WORDS_TEXT;
            }

            var resultList = new HashSet<string>();
            var checkPositions = new bool[startWord.Length];


            bool isWordTransformed = TransformWords(startWord, endWord, resultList, checkPositions);

            if (!isWordTransformed)
            {
                return WORDS_NOT_TRANSFORMED_TEXT;
            }

            return GenerateResultString(resultList);
        }

        private string GenerateResultString(HashSet<string> resultList)
        {
            var result = "";
            var lastIndex = resultList.Count - 1;
            for(int i = 0; i < resultList.Count; i++)
            {
                if( i == lastIndex)
                {
                    result += $" {resultList.ElementAt(i)}";
                }
                else
                {
                    result += $"{resultList.ElementAt(i)} -> ";
                }
            }

            return result;
        }

        private bool TransformWords(string currentWord, string endWord, HashSet<string> resultList, bool[] checkPositions)
        {
            if (resultList.Contains(currentWord))
            {
                return false;
            }

            resultList.Add(currentWord);

            if(currentWord == endWord)
            {
                return true;
            }

            if (!_spellChecker.IsWordSpelledCorrectly(currentWord))
            {
                resultList.Remove(currentWord);
                return false;
            }

            for(int i = 0; i < currentWord.Length; i++)
            {
                if (checkPositions[i])
                {
                    continue;
                }

                checkPositions[i] = true;
                var newWord = CreatNewWord(currentWord, endWord, i);
                var isWordTransformed = TransformWords(newWord, endWord, resultList, checkPositions);

                if (isWordTransformed)
                {
                    return true;
                }

                checkPositions[i] = false;
            }

            resultList.Remove(currentWord);
            return false;
        }

        private string CreatNewWord(string currentWord, string endWord, int index)
        {
            var newCharacter = endWord[index];
            var currentWordArray = currentWord.ToCharArray();
            currentWordArray[index] = newCharacter;
            return new string(currentWordArray);
        }
    }
}
