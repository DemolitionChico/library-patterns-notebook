namespace PatternsNotebook.Behavioral.Mediator.ChatRoomExample;

class Tester : TeamMember
{
    public Tester(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.Write($"{Name} ({nameof(Tester)}) has received: ");
        base.Receive(from, message);
    }
}