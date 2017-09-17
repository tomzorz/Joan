namespace Joan.Cyphers
{
    public class Atbash : AbstractCharacterMapCypher
    {
        public Atbash()
        {
            for (var i = 65; i < 91; i++)
            {
                Map[(char) i] = (char) (90 - (i - 65));
            }
        }
    }
}
