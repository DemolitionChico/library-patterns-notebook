namespace PatternsNotebook.Behavioral.State.BookingExample.BookingStates;

class ClosedState : BookingState
{
    private readonly string _reasonClosed;

    public ClosedState(string reason)
    {
        _reasonClosed = reason;
    }
    public override void EnterState(Booking booking)
    {
        Console.WriteLine($"> Entering closed state (Reason: {_reasonClosed})");
    }

    public override void Cancel(Booking booking)
    {
        Console.WriteLine("Invalid action, booking closed");
    }

    public override void DatePassed(Booking booking)
    {
        Console.WriteLine("Invalid action, booking closed");
    }

    public override void EnterDetails(Booking booking, string attendee, int ticketCount)
    {
        Console.WriteLine("Invalid action, booking closed");
    }
}