using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplates
{
    public class LanguageHandler
    {
        private readonly LanguageDescriptorAttribute _languageDescriptor;
        public Language Language =>
            _languageDescriptor.Language;
        public string Name =>
            _languageDescriptor.Name;
        public List<Problem> Problems { get; } = new List<Problem>();
        public LanguageHandler(LanguageDescriptorAttribute language, List<Problem> problems)
        {
            _languageDescriptor = language;
            foreach (var p in problems)
                Problems.Add(p);
        }
    }
}
