namespace PatternsNotebook.Behavioral.Mediator.ChatRoomExample;

public abstract class TeamMember
{
    private ChatRoom _chatRoom = null!;
    public string Name { get; }

    public TeamMember(string name)
    {
        Name = name;
    }

    internal void SetChatRoom(ChatRoom room)
    {
        _chatRoom = room;
    }

    public void Send(string message)
    {
        _chatRoom.Send(Name, message);
    }

    public virtual void Receive(string from, string message)
    {
        Console.WriteLine($"{from}: '{message}");
    }

    public virtual void SendTo<T>(string message) where T : TeamMember
    {
        _chatRoom.SendTo<T>(Name, message);
    }
}