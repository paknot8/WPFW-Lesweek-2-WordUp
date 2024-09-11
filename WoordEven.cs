public class WoordEven : Woord
{
    // <param name="tekst">De invoerstring voor het Woord-object.</param>
    public WoordEven(string tekst) : base(tekst) { }

    /// <returns>Het aantal klinkers in het Woord-object.</returns>
    public override int AantalKlinkers()
    {
        int klinkers = 0;

        // Loop door elk karakter in de invoerstring.
        // Controleer of het karakter een klinker is.
        foreach (char c in Tekst)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                klinkers++;
            }
        }
        return klinkers;
    }

    // <returns>Het aantal medeklinkers in het Woord-object.</returns>
    public override int AantalMedeklinkers()
    {
        int medeklinkers = 0;

        // Loop door elk karakter in de invoerstring.
        // Controleer of het karakter een letter is en geen klinker.
        foreach (char c in Tekst)
        {
            if (char.IsLetter(c) && c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u')
            {
                medeklinkers++;
            }
        }
        return medeklinkers;
    }
}