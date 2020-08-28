using ProjectTemplates;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EulerCSharp
{
    [LanguageDescriptor(Language.CSharp)]
    public static class CSharpLanguage
    {
        public static Action InitEntryPoint { get; } = Init;
        public static string Name => 
            "C#";
        public static List<(EulerProblemAttribute Problem, Func<string> EntryPoint)> Problems { get; } = 
            new List<(EulerProblemAttribute, Func<string>)>();

        private static List<IEulerProblem> problemInstances = new List<IEulerProblem>();

        static void Init()
        {
            var asm = Assembly.GetExecutingAssembly();
            var types = asm.ExportedTypes;
            foreach (var type in types
                .Where(a => !(a.GetCustomAttribute<EulerProblemAttribute>() is null)))
            {
                var instance = (IEulerProblem)asm.CreateInstance(type.FullName);
                problemInstances.Add(instance);
                Problems.Add((type.GetCustomAttribute<EulerProblemAttribute>(), instance.Run));
            }
        }
    }
}
