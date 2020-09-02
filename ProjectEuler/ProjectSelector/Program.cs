using ProjectTemplates;

using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace ProjectSelector
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Loading...");
            var locator = new LanguageLocator(Directory.GetCurrentDirectory());

            DisplayLanguages(locator);
        }

        private static void DisplayLanguages(LanguageLocator locator)
        {
            var languages = locator.Languages;
            var languageNames = languages.Select
                ((Func<LanguageHandler, (string Name, int StrLength)>)(a => (a.Name, a.Name.Length))).ToList();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select a language\n");
                for (var i = 0; i < languageNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {languageNames[i].Name}");
                }
                Console.WriteLine("\nTo exit, type \"Exit\"\n");
                var value = Console.ReadLine();
                if (value.ToLower() == "exit")
                    break;

                if (int.TryParse(value, out var languageNumber) && languageNumber <= languages.Count && languageNumber > 0)
                {
                    DisplayProblems(languages[languageNumber - 1]);
                    break;
                }
            }
        }

        private static void DisplayProblems(LanguageHandler language)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"({language.Name}) Select a problem\n");
                foreach (var problem in language.Problems)
                {
                    Console.WriteLine($"{problem.Number}: {problem.Name}");
                }
                Console.WriteLine("\nTo exit, type \"Exit\"\n");
                var probValue = Console.ReadLine();
                if (probValue.ToLower() == "exit")
                    break;

                if (int.TryParse(probValue, out var probNumber) && language.Problems.Select(a => a.Number).Contains(probNumber))
                {
                    var prob = language.Problems.Where(a => a.Number == probNumber).First();
                    DisplayProblem(prob);
                }
            }
        }

        private static void DisplayProblem(Problem problem)
        {
            Console.Clear();
            Console.WriteLine($"{problem.Number}: {problem.Name}");
            Console.WriteLine(problem.Description);
            Console.WriteLine("\nPress any key to begin.\n");
            Console.ReadKey(true);
            Console.WriteLine(problem.ProjectEulerSolutionEntryPoint());
            Console.WriteLine("\nPress any key to continue.\n");
            Console.ReadKey(true);
        }

        static string PrintLanguage(LanguageHandler handler) =>
            handler.Name;
    }
}
