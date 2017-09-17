using System.Collections.Generic;
using System.Linq;

namespace Joan
{
    public class Input
    {
        public Input(string input, bool isCaseInsensitive = true)
        {
            Original = input;
            Prepared = isCaseInsensitive ? input.ToUpperInvariant() : input;
            PreparedParts = input.Split(' ').ToList();
        }

        public string Original { get; }

        public string Prepared { get; }

        public List<string> PreparedParts { get; }

        public bool ProbablySolved { get; set; }
    }
}
