using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joan.Cyphers
{
    public class Vigenere : ICypher
    {
        private readonly string _key;
        private int _currentKeyCharIndex = 0; 

        public Vigenere(string key)
        {
            _key = key.ToUpperInvariant();
        }

        private char GetNextKeyChar()
        {
            if (_currentKeyCharIndex == _key.Length) _currentKeyCharIndex = 0;
            var c = _key[_currentKeyCharIndex];
            _currentKeyCharIndex += 1;
            return c;
        }

        public string Run(string input)
        {
            _currentKeyCharIndex = 0;
            return new string(input.ToCharArray().Select(x =>
            {
                if (x < 65 || x > 90) return x;
                var kc = GetNextKeyChar() - 65;
                return (char)(x - kc >= 65 ? x - kc : x - kc + 26);
            }).ToArray());
        }

        public bool SolutionPossible(string input) => input.LooksLikeText();

        public bool ShouldReRunSolution => false;

        public bool NeedsOriginalInput => false;
    }
}
