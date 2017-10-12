using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Joan.Cyphers
{
    public class MitnickMorse : ICypher
    {
        public string Run(string input)
        {
            return string.Join("",input.Select(x =>
            {
                switch (x)
                {
                    case '0':
                        return "-";
                    case '1':
                        return ".";
                    case '-':
                        return " ";
                    case ' ':
                        return Environment.NewLine;
                    default:
                        return " ";
                }
            }).ToArray());
        }

        public bool SolutionPossible(string input) => Regex.IsMatch(input, "^(([0-1]{1,6}-)*[0-1]{1,6} )+([0-1]{1,6}-)*[0-1]{1,6}$");

        public bool ShouldReRunSolution => true;

        public bool NeedsOriginalInput => true;
    }
}
