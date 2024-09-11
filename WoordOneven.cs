public class WoordOneven : Woord
{
    public WoordOneven(string tekst) : base(tekst) { }

    public override int AantalKlinkers()
    {
        int klinkers = 0;
        // Loop door elk karakter in de invoerstring.
        // Controleer of het karakter een klinker is.
        foreach (char c in Tekst)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                klinkers++; // Verhoog de teller voor het aantal klinkers.
            }
        }
        return klinkers;
    }

    public override int AantalMedeklinkers()
    {
        int medeklinkers = 0;
        // Loop door elk karakter in de invoerstring.
        // Controleer of het karakter een letter is en geen klinker.
        foreach (char c in Tekst)
        {
            if (char.IsLetter(c) && c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u')
            {
                medeklinkers++; // Verhoog de teller voor het aantal medeklinkers.
            }
        }
        return medeklinkers;
    }
}