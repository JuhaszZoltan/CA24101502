using CA24101502;
using System.Text;

List<Competior> competiors = [];

using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream) competiors.Add(new(sr.ReadLine()));

Console.WriteLine($"versenyt befejezok szama: {competiors.Count}");

//első célba érkező férfi
var f01 = competiors
    .Where(c => c.Gender)
    .MinBy(c => c.TotalTimeInSeconds);
Console.WriteLine($"elso celba ero ferfi: {f01}");

//korkategóriánként az átlagos depóban töltött
//idő átlagidő szerint növekvő sorrendben
var f02 = competiors
    .GroupBy(c => c.AgeCategory)
    .ToDictionary(
        g => g.Key,
        g => g
        .Average(c =>
        (c.RaceTimes["1st depot"] + 
        c.RaceTimes["2nd depot"]).TotalSeconds) / 2)
    .OrderBy(kvp => kvp.Value);

Console.WriteLine("kategoriankent az atlagos depoban toltott ido:");
foreach (var kvp in f02)
    Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value,6:0.00} sec.");




