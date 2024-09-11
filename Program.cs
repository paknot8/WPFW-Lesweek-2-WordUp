/*  --- WordUp1 ---
    Neem het programma KlinktBeter als uitgangspunt (je eigen versie of de standaarduitwerking die je gekregen hebt)
        - Pas het programma aan, splits de ‘Woord’ klasse van program.cs en sla op in een eigen bestand woord.cs 
        - Command line parameters: zorg dat het programma een parameter accepteert met daarin een pad naar 
        het invoerbestand  (mag ook via de properties)
        - Schrijf het uitvoerbestand met naam ‘uitvoer.txt’ op dezelfde plaats weg als waar het invoerbestand staat
        - Dus bijv. deze aanroep:  .\WordUp1.exe C:\\Temp\\invoer.txt
        - Heeft als uitvoerbestand:  C:\Temp\uitvoer.txt
*/

/* --- WordUp2 ---
    Neem het programma Wordup1 als uitgangspunt, pas het programma zodanig aan dat:
        - Er een class Tekst is die alle woorden van een tekst in zich heeft in een list van woorden
        - Deze klasse heeft ook een attribuut van type ‘struct’ waarin de gegevens van het invoerbestand worden bewaard, gescheiden in pad en filenaam
        - Geeft Tekst een methode GetWoorden() die de list met woorden teruggeeft zodat ze kunnen worden afgedrukt
        - Geef Tekst een methode DraaiOm() die de volgorde van alle woorden omdraait (en dus opslaat in Tekst)
*/

/* --- WordUp3 ---
    Neem het programma Wordup2 als uitgangspunt, pas het programma zodanig aan dat:
        - de class Tekst ook een methode Palindromen() heeft die alle woorden teruggeeft die palindromen zijn 
        - (dat zijn woorden die als je ze omdraait nog steeds hetzelfde zijn, dus ‘negen’ of ‘racecar’ of ‘lol’, etc.
        - pas je programma aan zodat ook dit in de outputfile terecht komt
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
            if (args.Length == 0) // if there is no file ex: dotnet run invoer.txt
            {
                Console.WriteLine("Error: No input file specified.");
                return;
            }

            string invoerBestand = args[0]; // takes the first file it sees
            if (!File.Exists(invoerBestand))
            {
                Console.WriteLine($"Error: Input file '{invoerBestand}' does not exist.");
                return;
            }
            OpdrachtWordUp(args);
        }

        public static void OpdrachtWordUp(string[] args)
        {
            string invoerBestand = args[0]; // takes the first file it sees
            string bestandInhoud = File.ReadAllText(invoerBestand);
            List<Woord> woordLijst = OpdrachtKlinkers(bestandInhoud);
            SchrijfUitvoerBestand(invoerBestand, woordLijst);
        }

        // Processes the input file content and returns a list of Woord objects
        public static List<Woord> OpdrachtKlinkers(string bestandInhoud)
        {
            string tekst = VerwijderBijzondereTekens(bestandInhoud);
            string[] woorden = SplitTekstInWoorden(tekst);
            return MaakWoordLijst(woorden);
        }

        // Removes special characters from the input text and converts to lowercase
        private static string VerwijderBijzondereTekens(string tekst)
        {
            return MyRegex().Replace(tekst, "").ToLower();
        }

        // Splits the input text into individual words
        private static string[] SplitTekstInWoorden(string tekst)
        {
            return tekst.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        // Creates a list of Woord objects from the input words
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

        // Writes the output to a file named "uitvoer.txt" in the same directory as the input file
        private static void SchrijfUitvoerBestand(string invoerBestand, List<Woord> woordLijst)
        {
            string invoerDir = Path.GetDirectoryName(invoerBestand);
            string uitvoerBestandNaam = Path.Combine(invoerDir, "uitvoer.txt");

            if (File.Exists(uitvoerBestandNaam))
            {
                if (new FileInfo(uitvoerBestandNaam).Length > 0)
                {
                    Console.WriteLine($"Error: Output file '{uitvoerBestandNaam}' already exists and is not empty.");
                    return;
                }
            }

            using StreamWriter writer = File.CreateText(uitvoerBestandNaam);
            foreach (Woord w in woordLijst)
            {
                writer.WriteLine($"Woord: {w.Tekst}, Klinkers: {w.AantalKlinkers()}, Medeklinkers: {w.AantalMedeklinkers()}");
            }
        }

        // Returns a Regex object that matches any character that is not a word character or whitespace
        private static Regex MyRegex()
        {
            return new Regex(@"[^\w\s]");
        }
    }
}