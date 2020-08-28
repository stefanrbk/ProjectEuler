using System;

namespace ProjectTemplates
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class EulerProblemAttribute : Attribute
    {
        public readonly Language Language;
        public readonly int ProblemNumber;
        public readonly string Name;
        public readonly string Description;

        public EulerProblemAttribute(Language language, int problemNum, string name, string description)
        {
            Language = language;
            ProblemNumber = problemNum;
            Name = name;
            Description = description;
        }
    }
}
