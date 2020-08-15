using System;

namespace ProjectTemplates
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class EulerProblemAttribute : Attribute
    {
        public readonly int ProblemNumber;
        public readonly string Description;

        public EulerProblemAttribute(int problemNum, string description)
        {
            ProblemNumber = problemNum;
            Description = description;
        }
    }
}
