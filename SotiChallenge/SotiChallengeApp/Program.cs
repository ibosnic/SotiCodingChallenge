using System;

namespace SotiChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Start Word:");
            var startWord = Console.ReadLine().ToUpper();

            Console.WriteLine("input End Word:");
            var endWord = Console.ReadLine().ToUpper();

            var service = new WordTransformationService(new EnglishSpellChecker());
            var result = service.TransformWords(startWord, endWord);
            Console.WriteLine($"Result: {result}");

            Console.ReadLine();
        }
    }
}
