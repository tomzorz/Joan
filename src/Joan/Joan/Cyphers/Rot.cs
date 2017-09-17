using System;

namespace Joan.Cyphers
{
    public class Rot : AbstractCharacterMapCypher
    {
        public Rot(int shift)
        {
            if(shift > 26 || shift < 1) throw new ArgumentOutOfRangeException(nameof(shift));
            for (var i = 0; i < 26; i++)
            {
                Map[(char) (65 + i)] = 65 + i + shift > 90 ? (char) (39 + i + shift) : (char) (65 + i + shift);
            }
        }
    }
}
