using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Joan.Cyphers
{
    public class OctalAscii : ICypher
    {
        public string Run(string input)
        {
            try
            {
                return new string(input.Split(' ').Select(x => (char)Convert.ToInt32(x.Trim(), 8)).ToArray());
            }
            catch
            {
                return "";
            }
        }

        public bool SolutionPossible(string input) => Regex.IsMatch(input, @"\b[0-7]{3}\b");

        public bool ShouldReRunSolution => true;

        public bool NeedsOriginalInput => true;
    }
}
