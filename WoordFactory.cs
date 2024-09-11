// Een statische klasse die verantwoordelijk is voor het creëren van Woord-objecten.
// Factory Class
public static class WoordFactory
{
    public static Woord MaakWoord(string tekst)
    {
        // Controleer of de lengte van de invoerstring even is.
        // Als de teskt in tweeen gedeeld kan worden zonder extra "0" is dit even
        // anders is het oneven als het niet == 0 als antwoord is.
        if (tekst.Length % 2 == 0)
        {
            return new WoordEven(tekst); // Maak een nieuw WoordEven-object aan als de lengte even is.
        }
        else
        {
            return new WoordOneven(tekst); // Maak een nieuw WoordOneven-object aan als de lengte oneven is.
        }
    }
}