public class Assignment
{
    private readonly string _studentName;
    private readonly string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetStudentName() => _studentName;
    public string GetTopic() => _topic;
    public string GetSummary() => $"{_studentName} - {_topic}";
}