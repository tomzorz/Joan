using System.Text.RegularExpressions;

namespace Joan
{
    public static class Utilities
    {
        public static bool LooksLikeText(this string test) => Regex.IsMatch(test, @"[A-Z]");
    }
}
