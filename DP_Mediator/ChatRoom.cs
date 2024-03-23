namespace DesignPatterns.Mediator;

public class ChatRoom
{
    private List<Person> _people = new List<Person>();
    public void Join(Person person)
    {
        string joinMsg = $"{person.Name} joins the chat";
        Broadcast("room", joinMsg);
        person.Room = this;
        _people.Add(person);
    }

    public void Broadcast(string source, string message)
    {
        foreach (var p in _people.Where(p => p.Name != source))
        {
            p.Receive(source, message);
        }
    }

    public void Message(string source, string destination, string message)
    {
        _people.FirstOrDefault(p => p.Name == destination)
            ?.Receive(source, message);
    }
}