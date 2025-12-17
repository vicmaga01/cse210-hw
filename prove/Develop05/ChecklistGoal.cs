class ChecklistGoal : Goal
{
    private int _count;
    private readonly int _target;
    private readonly int _bonus;
    private bool _complete;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus, int count = 0, bool complete = false)
        : base(name, desc, points)
    {
        _target = Math.Max(1, target);
        _bonus = Math.Max(0, bonus);
        _count = Math.Max(0, count);
        _complete = complete && _count >= _target;
    }
    
    public override bool IsComplete => _complete;
    public override int RecordEvent()
    {
        if (_complete) return 0;

        _count++;
        var earned = Points;
        if (_count >= _target)
        {
            _complete = true;
            earned += _bonus;
        }
        return earned;
    }

    public override string GetStatus()
    {
        var status = _complete ? "Completed" : $"Comleted {_count}/{_target} times";
        return $"{Name} - {Description} (Checklist, {status}) +{Points} each; bonus +{_bonus} at {_target}";
    }

    public override string Serialize() =>
        $"Checklist| {Name}|{Description}|{Points}| {_count}|{_target}|{_bonus}|{(_complete ? "1" : "0")}";

}