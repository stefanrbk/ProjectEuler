using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplates
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class LanguageDescriptorAttribute : Attribute
    {
        public Language Language { get; }
        public LanguageDescriptorAttribute(Language language) => 
            Language = language;
    }
}
