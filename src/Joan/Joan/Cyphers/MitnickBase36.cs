using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Joan.Cyphers
{
    public class MitnickBase36 : ICypher
    {
        private readonly Dictionary<char, int> _valueMap = new Dictionary<char, int>();
        private readonly StringBuilder _sb;

        public MitnickBase36()
        {
            for (var i = 0; i < 10; i++)
            {
                _valueMap[i.ToString()[0]] = i;
            }
            for (var i = 0; i < 26; i++)
            {
                _valueMap[(char)(65 + i)] = 10 + i;
            }
            _sb = new StringBuilder();
        }
        
        public string Run(string input)
        {
            var split = input.Split(' ');
            _sb.Clear();
            foreach (var s in split)
            {
                var cv = 0;
                var pow = 0;
                foreach (var ch in s.Reverse())
                {
                    cv += (int)(Math.Pow(36, pow) * _valueMap[ch]);
                    pow += 1;
                }
                _sb.Append((char) cv);
            }
            return _sb.ToString();
        }

        public bool SolutionPossible(string input) => Regex.IsMatch(input, "^([A-Z0-9]{1,2} )+[A-Z0-9]{1,2}$") && input.Contains(" W ");

        public bool ShouldReRunSolution => true;

        public bool NeedsOriginalInput => true;
    }
}
