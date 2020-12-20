using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotiChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Start Word:");
            var startWord = Console.ReadLine();

            Console.WriteLine("input End Word:");
            var endWord = Console.ReadLine();

            var service = new WordTransformationService(new EnglishSpellChecker());
            var result = service.TransformWords(startWord, endWord);
            Console.WriteLine($"Result: {result}");

            Console.ReadLine();
        }
    }
}
