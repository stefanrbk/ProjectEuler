using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectTemplates
{
    public class LanguageLocator
    {
        public List<LanguageHandler> Languages { get; } = new List<LanguageHandler>();
        public LanguageLocator(string directory)
        {
            DirectoryInfo directoryInfo;
            if (!System.IO.Directory.Exists(directory))
                throw new DirectoryNotFoundException($"The path \"{directory}\" is not a directory.");
                
            directoryInfo = new DirectoryInfo(directory);

            foreach (var file in directoryInfo.EnumerateFiles())
            {
                try
                {
                    var asm = Assembly.LoadFrom(file.FullName);
                    var languages = asm.ExportedTypes;
                    foreach (var lang in languages)
                    {
                        var attr = lang.GetCustomAttribute<LanguageDescriptorAttribute>();
                        if (!(attr is null))
                        {
                            var initEntryPoint = lang.GetProperty("InitEntryPoint", typeof(Action))?.GetMethod;
                            if (!(initEntryPoint is null))
                                ((Action)initEntryPoint.Invoke(null, null))();

                            var problems = lang.GetProperty("Problems", typeof(List<Problem>));
                            var handler = new LanguageHandler(attr, (List<Problem>)problems.GetGetMethod().Invoke(null, null));
                            Languages.Add(handler);
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    continue;
                }
                catch (FileLoadException)
                {
                    continue;
                }
                catch (BadImageFormatException)
                {
                    continue;
                }
            }
        }
    }
}
