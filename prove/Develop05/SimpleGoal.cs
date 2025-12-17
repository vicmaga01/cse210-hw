using System.Reflection.Metadata.Ecma335;

class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string desc, int points, bool completed = false) : base(name, desc, points)
    {
        _completed = completed;
    }
    public override bool IsComplete => _completed;

    public override int RecordEvent()
    {
      if (_completed) return 0;
      _completed = true;
      return Points; 
    }
    public override string GetStatus() => 
        $"{Name} - {Description} (SimpleGoal, {(IsComplete ? "Completed" : "Not completed")}) worth {Points}";
    public override string Serialize() =>
        $"Simple|{Name}|{Description}|{Points}|{(_completed ? "1" : "0")}";
}