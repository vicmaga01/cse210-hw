class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points){ }
    public override bool IsComplete => false; 
    public override int RecordEvent() => Points;
    public override string GetStatus() =>
        $"{Name} - {Description} (Eternal) +{Points} each time";
    public override string Serialize() =>
        $"Eternal{Name}|{Description}|{Points}";
}
