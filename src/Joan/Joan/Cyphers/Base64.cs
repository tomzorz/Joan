using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Joan.Cyphers
{
    public class Base64 : ICypher
    {
        public string Run(string input) => Encoding.ASCII.GetString(Convert.FromBase64String(input));

        public bool SolutionPossible(string input) => Regex.IsMatch(input, "^(?:[A-Za-z0-9+]{4})*(?:[A-Za-z0-9+]{2}==|[A-Za-z0-9+]{3}=)?$");

        public bool ShouldReRunSolution => true;

        public bool NeedsOriginalInput => true;
    }
}