using ProjectTemplates;

using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace ProjectSelector
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Loading...");
            var locator = new LanguageLocator(Directory.GetCurrentDirectory());

            var languages = locator.Languages;
            var languageNames = languages.Select<LanguageHandler, (string Name, int StrLength)>
                (a => {
                    var lang = PrintLanguage(a);
                    return (lang, lang.Length);
                }).ToList();


            
            while (true)
            {
                Console.WriteLine("Select a language\n\n");
                for (var i = 0; i < languageNames.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {languageNames[i].Name}");
                }
                Console.WriteLine("\nTo exit, type \"Exit\"");
                var value = Console.ReadLine();
                if (value.ToLower() == "exit")
                    break;

                if (int.TryParse(value, out var languageNumber) && languageNumber <= languages.Count && languageNumber > 0)
                {
                    while (true) 
                    {
                        var lang = languages[languageNumber - 1];
                        foreach (var problem in lang.Problems)
                        {
                            Console.WriteLine($"{problem.Number}: {problem.Name}");
                        }
                        Console.WriteLine("\nTo exit, type\"Exit\"");
                        var probValue = Console.ReadLine();
                        if (probValue.ToLower() == "exit")
                            break;

                        if (int.TryParse(probValue, out var probNumber) && lang.Problems.Select(a => a.Number).Contains(probNumber))
                        {
                            var prob = lang.Problems.Where(a => a.Number == probNumber).First();
                            Console.WriteLine($"{prob!.Number}: {prob!.Name}");
                            Console.WriteLine(prob!.Description);
                            Console.WriteLine("Press any key to begin.");
                            Console.Read();
                            Console.WriteLine(prob!.ProjectEulerSolutionEntryPoint());
                            Console.Read();
                        }
                    }
                    break;
                }
            }
        }
        static string PrintLanguage(LanguageHandler handler) =>
            handler.Name;
    }
}
