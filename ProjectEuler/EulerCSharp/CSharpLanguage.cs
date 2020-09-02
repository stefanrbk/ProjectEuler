using ProjectTemplates;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EulerCSharp
{
    [LanguageDescriptor(Language.CSharp, "C#")]
    public static class CSharpLanguage
    {
        public static Action InitEntryPoint { get; } = Init;
        public static List<Problem> Problems { get; } = new List<Problem>();

        static void Init()
        {
            var asm = Assembly.GetExecutingAssembly();
            var types = asm.ExportedTypes;
            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<EulerProblemAttribute>();
                if (!(attr is null))
                {
                    var prob = (IEulerProblem)asm.CreateInstance(type.FullName);
                    Problems.Add(new Problem(prob, "RunSolution"));
                }
            }
        }
    }
}
