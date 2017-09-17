using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Joan
{
    public static class ResourceReader
    {
        public static List<string> ReadDictionary(string language)
        {
            var assembly = typeof(Program).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream($"Joan.Dictionaries.{language}.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    var data = reader.ReadToEnd();
                    return data.Split('\n').Select(x => x.Trim().ToUpper()).ToList();
                }
            }
        }
    }
}
