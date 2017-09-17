using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Joan.Cyphers
{
    public class HexAscii : ICypher
    {
        public string Run(string input)
        {
            try
            {
                return new string(input.Split(' ').Select(x => (char)int.Parse(x.Trim(), NumberStyles.HexNumber)).ToArray());
            }
            catch
            {
                return "";
            }
        }

        public bool SolutionPossible(string input) => Regex.IsMatch(input, @"\b[0-9A-F]{2}\b");

        public bool ShouldReRunSolution => true;

        public bool NeedsOriginalInput => true;
    }
}
