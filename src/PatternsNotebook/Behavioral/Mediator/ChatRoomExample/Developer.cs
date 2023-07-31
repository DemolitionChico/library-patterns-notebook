namespace PatternsNotebook.Behavioral.Mediator.ChatRoomExample;

class Developer : TeamMember
{
    public Developer(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.Write($"{Name} ({nameof(Developer)}) has received: ");
        base.Receive(from, message);
    }
}