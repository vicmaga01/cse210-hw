using System;
using System.Globalization;

class Program
{
    private static readonly List<Goal> _goals = new();
    private static int _score = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine("1) Create New Goal");
            Console.WriteLine("2) List Goals");
            Console.WriteLine("3) Save Goal");
            Console.WriteLine("4) Load Goals");
            Console.WriteLine("5) Record Event");
            Console.WriteLine("6) Show Score");
            Console.WriteLine("7) Quit");
            Console.WriteLine("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1": CreateGoalFlow(); break;
                case "2": ListGoals(); break;
                case "3": Console.Write("File path to save (e.g., goals.txt): "); Save(Console.ReadLine() ?? "goals.txt"); break;  
                case "4": Console.Write("File path to load: "); Load(Console.ReadLine() ?? "goals.txt"); break;
                case "5": RecordEventFlow(); break;
                case "6": Console.WriteLine($"Current score: {_score}"); break;
                case "7": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }
    private static void CreateGoalFlow()
    {
        Console.WriteLine("Select Goal Type: ");
        Console.WriteLine(" 1) Simple");
        Console.WriteLine(" 2) Eternal");
        Console.WriteLine(" 3) Checklist");
        Console.WriteLine("Type: ");
        var type = Console.ReadLine();

        Console.Write("Name: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("Short description: ");
        var desc = Console.ReadLine() ?? "";
        var points = ReadInt("Points for each completion: ");

        switch (type)
        {
            case "1": _goals.Add(new SimpleGoal(name, desc, points)); break;
            case "2": _goals.Add(new EternalGoal(name, desc, points)); break;
            case "3": 
                var target = ReadInt("Times required to complete: ");
                var bonus = ReadInt("Bonus points on final completion: ");
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus)); break;
            default: Console.WriteLine("Unknown goal type."); break;
        }
    }

    private static void ListGoals(bool showIndices = false)
    {
        if (_goals.Count == 0) {Console.WriteLine("No goals created."); return;}
        for (int i = 0; i< _goals.Count; i++)
        {
            var g = _goals[i];
            var prefix = showIndices ? $"{i + 1}." : "-";
            var box = g.IsComplete? "[X]" : "[ ]";
            Console.WriteLine($"{prefix}{box} {g.GetStatus()}");
        }
    }

    private static void RecordEventFlow()
    {
        if (_goals.Count == 0) {Console.WriteLine("No goals yet."); return; }
        ListGoals(showIndices: true);
        var idx = ReadInt("Enter goal number to record: ") - 1;
        if (idx < 0 || idx >= _goals.Count) {Console.WriteLine("Invalid goal number."); return; }

        int earned = _goals[idx].RecordEvent();
        _score += earned;
        Console.WriteLine($"Event recorded! You earned {earned} points.");
    }

    private static void Save(string path)
    {
        using var w = new StreamWriter(path);
        w.WriteLine(_score);
        foreach (var g in _goals) w.WriteLine(g.Serialize());
        Console.WriteLine($"Saved {_goals.Count} goal(s) to {path}.");
    }

    private static void Load(string path)
    {
        if (!File.Exists(path)) {Console.WriteLine("File not found."); return; }

        var lines = File.ReadAllLines(path);
        _goals.Clear();
        _score = 0;
        
        if (lines.Length == 0) {Console.WriteLine("Empty file."); return; }

        if (!int.TryParse(lines[0], out _score)) _score = 0;

        for (int i = 1; i < lines.Length; i++)
        {
            var g = Goal.Deserialize(lines[i]);
            if (g != null) _goals.Add(g);
        }
        Console.WriteLine($"Loaded {_goals.Count} goal(s) from {path}.");
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v) && v >= 0) return v;
            Console.WriteLine("Please enter a non-negative integer.");
        }
    }
}

    