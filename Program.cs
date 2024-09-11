/*  --- WordUp1 ---
    - Neem het programma KlinktBeter als uitgangspunt (je eigen versie of de standaarduitwerking die je gekregen hebt)
    - Pas het programma aan, splits de ‘Woord’ klasse van program.cs en sla op in een eigen bestand woord.cs 
    - Command line parameters: zorg dat het programma een parameter accepteert met daarin een pad naar 
    het invoerbestand  (mag ook via de properties)
    - Schrijf het uitvoerbestand met naam ‘uitvoer.txt’ op dezelfde plaats weg als waar het invoerbestand staat
    - Dus bijv. deze aanroep:  .\WordUp1.exe C:\\Temp\\invoer.txt
    - Heeft als uitvoerbestand:  C:\Temp\uitvoer.txt
*/

using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace WPFW_Lesweek_2_WordUp1
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Error: No input file specified.");
                return;
            }

            string invoerBestand = args[0];
            string bestandInhoud = File.ReadAllText(invoerBestand);
            List<Woord> woordLijst = OpdrachtKlinkers(bestandInhoud);
            SchrijfUitvoerBestand(invoerBestand, woordLijst);
        }

        public static List<Woord> OpdrachtKlinkers(string bestandInhoud)
        {
            string tekst = VerwijderBijzondereTekens(bestandInhoud);
            string[] woorden = SplitTekstInWoorden(tekst);
            return MaakWoordLijst(woorden);
        }

        private static string VerwijderBijzondereTekens(string tekst)
        {
            return MyRegex().Replace(tekst, "").ToLower();
        }

        private static string[] SplitTekstInWoorden(string tekst)
        {
            return tekst.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static List<Woord> MaakWoordLijst(string[] woorden)
        {
            List<Woord> woordLijst = new List<Woord>();
            foreach (string woord in woorden)
            {
                Woord w = WoordFactory.MaakWoord(woord);
                woordLijst.Add(w);
            }
            return woordLijst;
        }

        private static void SchrijfUitvoerBestand(string invoerBestand, List<Woord> woordLijst)
        {
            if (string.IsNullOrEmpty(invoerBestand))
            {
                Console.WriteLine("Error: Input file path is null or empty.");
                return;
            }

            if (!string.IsNullOrEmpty(invoerBestand))
            {
                string uitvoerBestandNaam = invoerBestand.Substring(0, invoerBestand.LastIndexOf('\\'));
                uitvoerBestandNaam = Path.Combine(uitvoerBestandNaam, "uitvoer.txt");
                using StreamWriter writer = File.CreateText(uitvoerBestandNaam);

                foreach (Woord w in woordLijst)
                {
                    writer.WriteLine($"Woord: {w.Tekst}, Klinkers: {w.AantalKlinkers()}, Medeklinkers: {w.AantalMedeklinkers()}");
                }
            }
            else
            {
                Console.WriteLine("Error: Input file path is null or empty.");
            }
        }

        [GeneratedRegex(@"[^a-zA-Z0-9\s]")]
        private static partial Regex MyRegex();
    }
}