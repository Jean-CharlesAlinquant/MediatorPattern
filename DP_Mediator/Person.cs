namespace DesignPatterns.Mediator;

public class Person
{
    public Person(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    private List<string> _chatLog = new List<string>();
    public string Name { get; set; }
    public ChatRoom? Room { get; set; }

    public void Say(string message)
    {
        Room?.Broadcast(Name, message);
    }

    public void PrivateMessage(string receiver, string message)
    {
        Room?.Message(Name, receiver, message);
    }

    public void Receive(string sender, string message)
    {
        string s = $"{sender}: '{message}'";
        _chatLog.Add(s);
        Console.WriteLine($"[{Name}'s chat session] {s}");
    }
}
