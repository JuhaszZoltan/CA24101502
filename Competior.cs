namespace CA24101502;

internal class Competior
{
    public string Name { get; set; }
    public int YearOfBirth { get; set; }
    public string RaceNumber { get; set; }
    public bool Gender { get; set; }
    public string AgeCategory { get; set; }
    public Dictionary<string, TimeSpan> RaceTimes { get; set; }

    public int TotalTimeInSeconds => (int)RaceTimes.Values.Sum(ts => ts.TotalSeconds);

    public override string ToString() =>
        $"[{RaceNumber}] {Name} ({(Gender ? "férfi" : "nő")} {AgeCategory})";

    public Competior(string row)
    {
        var v = row.Split(';');

        Name = v[0];
        YearOfBirth = int.Parse(v[1]);
        RaceNumber = v[2];
        Gender = v[3] == "f";
        AgeCategory = v[4];
        RaceTimes = new()
        {
            { "swimming",  TimeSpan.Parse(v[5]) },
            { "1st depot", TimeSpan.Parse(v[6]) },
            { "cycling",   TimeSpan.Parse(v[7]) },
            { "2nd depot", TimeSpan.Parse(v[8]) },
            { "running",   TimeSpan.Parse(v[9]) },
        };
    }
}
