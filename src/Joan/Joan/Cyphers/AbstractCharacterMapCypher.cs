using System.Collections.Generic;
using System.Linq;

namespace Joan.Cyphers
{
    public abstract class AbstractCharacterMapCypher : ICypher
    {
        protected readonly Dictionary<char, char> Map;

        protected AbstractCharacterMapCypher()
        {
            Map = new Dictionary<char, char>();
        }

        public virtual string Run(string input) => new string(input.ToCharArray().Select(x => !Map.ContainsKey(x) ? x : Map[x]).ToArray());

        public bool SolutionPossible(string input) => input.LooksLikeText();

        public bool ShouldReRunSolution => false;

        public bool NeedsOriginalInput => false;
    }
}
