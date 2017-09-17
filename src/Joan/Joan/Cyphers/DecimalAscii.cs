using System.Linq;
using System.Text.RegularExpressions;

namespace Joan.Cyphers
{
    public class DecimalAscii : ICypher
    {
        public string Run(string input)
        {
            try
            {
                return new string(input.Split(' ').Select(x => (char)int.Parse(x.Trim())).ToArray());
            }
            catch
            {
                return "";
            }
        }

        public bool SolutionPossible(string input) => Regex.IsMatch(input, @"\b(\d+)\b");

        public bool ShouldReRunSolution => true;

        public bool NeedsOriginalInput => true;
    }
}
