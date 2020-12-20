using System;

namespace SotiChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input start word and end word ex.startword,endword:");
            var words = Console.ReadLine();
            var wordsArray = words.Split(',');
            var startWord = wordsArray.Length == 2 ? wordsArray[0].Trim().ToUpper() : string.Empty;
            var endWord = wordsArray.Length == 2 ? wordsArray[1].Trim().ToUpper() : string.Empty;

            var service = new WordTransformationService(new EnglishSpellChecker());
            var result = service.TransformWords(startWord, endWord);
            Console.WriteLine($"Result: {result}");

            Console.ReadLine();
        }
    }
}
