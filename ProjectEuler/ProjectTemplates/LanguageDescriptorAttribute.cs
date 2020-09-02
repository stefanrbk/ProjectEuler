using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplates
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class LanguageDescriptorAttribute : Attribute
    {
        public string Name { get; }
        public Language Language { get; }
        public LanguageDescriptorAttribute(Language language, string name)
        {
            Language = language;
            Name = name;
        }
    }
}
