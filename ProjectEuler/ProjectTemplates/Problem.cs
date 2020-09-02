using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectTemplates
{
    public class Problem
    {
        private EulerProblemAttribute _metadata;
        public Func<string> ProjectEulerSolutionEntryPoint { get; }
        public Language Language => _metadata.Language;
        public string Name => _metadata.Name;
        public string Description => _metadata.Description;
        public int Number => _metadata.ProblemNumber;

        public Problem(IEulerProblem instance, string entryPoint)
        {
            ProjectEulerSolutionEntryPoint = () => (string)instance.GetType().GetMethod(entryPoint).Invoke(instance, null);
            _metadata = instance.GetType().GetCustomAttribute<EulerProblemAttribute>();
        }
    }
}
