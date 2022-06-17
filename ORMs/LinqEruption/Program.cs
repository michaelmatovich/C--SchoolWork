using System.Collections.Generic;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!


//First Chile
IEnumerable<Eruption> ChileEruption = eruptions.Where(e => e.Location == "Chile").Take(1).ToList();
PrintEach(ChileEruption, "Chile Eruptions:");

//Hawaii
IEnumerable<Eruption> HawaiiEruption = eruptions.Where(e => e.Location == "Hawaiian Is").ToList();
PrintEach(HawaiiEruption, "Hawaii");

//New Zealand
Eruption NewZealandEruption = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
Console.WriteLine(NewZealandEruption.ToString());

//Over 2000 meters
IEnumerable<Eruption> EruptionsOver2000 = eruptions.Where(e => e.ElevationInMeters > 2000).ToList();
PrintEach(EruptionsOver2000, "Eruptions over 2000 M:");

//Starts with Z
IEnumerable<Eruption> NameStartsWithZ = eruptions.Where(e => e.Volcano.StartsWith("Z")).ToList();
PrintEach(NameStartsWithZ, "Eruptions starting with a Z.");
int count = eruptions.Count(e => e.Volcano.StartsWith("Z"));
Console.WriteLine(count);

//Highest Elevation
int HighestElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine(HighestElevation);

//Name of Highest Elevation Volcano
Eruption HighestElevationVolcano = eruptions.First(e => e.ElevationInMeters == HighestElevation);
Console.WriteLine(HighestElevationVolcano.Volcano);

//EruptionsBefore1000
IEnumerable<Eruption> EruptionsBefore1000CE = eruptions.Where(e => e.Year < 1000).OrderBy(er => er.Volcano).ToList();
PrintEach(EruptionsBefore1000CE, "EruptionsBefore1000");


// Volcanos sorted alphabetically
IEnumerable<Eruption> SortedEruptions = eruptions.OrderBy(e => e.Volcano).ToList();
PrintEach(SortedEruptions, "Sorted Alphabetically");














// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
