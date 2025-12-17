abstract class Goal
{
    private readonly string _name;
    private readonly string _desc;
    private readonly int _points;

    protected Goal(string name, string desc, int points)
    {
        _name = name;
        _desc = desc;
        _points = points;
    }

    public string Name => _name;
    public string Description => _desc;
    public int Points => _points;

    public abstract bool IsComplete {get; }
    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();

    public static Goal? Deserialize(string line)
    {
        if (string .IsNullOrWhiteSpace(line)) return null;
        var parts = line.Split("|");
        if (parts.Length < 4) return null;

        var type = parts[0];
        var name = parts[1];
        var desc = parts[2];
        _= int.TryParse(parts[3], out var pts);

        switch (type)
        {
            case "Simple":
                bool completed = parts.Length >= 5 && parts[4] == "1";
                return new SimpleGoal(name, desc, pts, completed);
            case "Eternal":
                return new EternalGoal(name, desc, pts);
            case "Checklist":
                _= int.TryParse(parts.ElementAtOrDefault(4) ?? "0", out var count);
                _= int.TryParse(parts.ElementAtOrDefault(5) ?? "1", out var target);
                _= int.TryParse(parts.ElementAtOrDefault(6) ?? "0", out var bonus);
                bool done = parts.ElementAtOrDefault(7) == "1";
                return new ChecklistGoal(name, desc, pts, target, bonus, count, done);
            default:
                return null;
        }
    }
}