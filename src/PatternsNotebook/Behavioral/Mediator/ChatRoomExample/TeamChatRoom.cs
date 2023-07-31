namespace PatternsNotebook.Behavioral.Mediator.ChatRoomExample;

class TeamChatRoom : ChatRoom
{
    private List<TeamMember> _members = new List<TeamMember>();

    public override void Register(TeamMember member)
    {
        member.SetChatRoom(this);
        _members.Add(member);
    }

    public override void Send(string from, string message)
    {
        _members.ForEach(m => m.Receive(from, message));
    }

    public override void SendTo<T>(string from, string message)
    {
        _members.OfType<T>().ToList().ForEach(m => m.Receive(from, message));
    }

    public void RegisterMembers(params TeamMember[] teamMembers)
    {
        foreach (var member in teamMembers)
        {
            Register(member);
        }
    }
}