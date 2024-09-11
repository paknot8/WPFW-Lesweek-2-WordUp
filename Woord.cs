public abstract class Woord
{
    public string Tekst { get; set; }

    public Woord(string tekst)
    {
        Tekst = tekst; // Initialiseer de tekst van het Woord-object.
    }

    // Een abstracte methode die het aantal klinkers en medeklinkers in het Woord-object moet retourneren.
    public abstract int AantalKlinkers();
    public abstract int AantalMedeklinkers();
}