using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Joan.Cyphers
{
    public class Morse : ICypher
    {
        private readonly Dictionary<string, string> _map = new Dictionary<string, string>
        {
            [".-"] = "a",
            ["-..."] = "b",
            ["-.-."] = "c",
            ["-.."] = "d",
            ["."] = "e",
            ["..-."] = "f",
            ["--."] = "g",
            ["...."] = "h",
            [".."] = "i",
            [".---"] = "j",
            ["-.-"] = "k",
            [".-.."] = "l",
            ["--"] = "m",
            ["-."] = "n",
            ["---"] = "o",
            [".--."] = "p",
            ["--.-"] = "q",
            [".-."] = "r",
            ["..."] = "s",
            ["-"] = "t",
            ["..-"] = "u",
            ["...-"] = "v",
            [".--"] = "w",
            ["-..-"] = "x",
            ["-.--"] = "y",
            ["--.."] = "z",
            ["-----"] = "0",
            [".----"] = "1",
            ["..---"] = "2",
            ["...--"] = "3",
            ["....-"] = "4",
            ["....."] = "5",
            ["-...."] = "6",
            ["--..."] = "7",
            ["---.."] = "8",
            ["----."] = "9",
            [".-.-.-"] = ".",
            ["-....-"] = "-",
            ["..--.."] = "?",
            ["---..."] = ":"
        };

        private readonly StringBuilder _sb;
        
        public Morse()
        {
            _sb = new StringBuilder();
        }

        public string Run(string input)
        {
            _sb.Clear();
            var words = input.Split(Environment.NewLine);
            foreach (var word in words)
            {
                var letters = word.Trim().Split(' ');
                foreach (var letter in letters)
                {
                    if (_map.ContainsKey(letter)) _sb.Append(_map[letter]);
                }
                _sb.Append(" ");
            }
            return _sb.ToString().ToUpperInvariant();
        }

        public bool SolutionPossible(string input) => Regex.IsMatch(input, "([.-]+ )+[.-]+");

        public bool ShouldReRunSolution => false;

        public bool NeedsOriginalInput => true;
    }
}
