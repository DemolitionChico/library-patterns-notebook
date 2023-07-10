namespace PatternsNotebook.Behavioral.State.BookingExample.BookingStates;

class NewState : BookingState
{
    public override void EnterState(Booking booking)
    {
        Console.WriteLine("> Entering new state");
        booking.BookingId = new Random().Next();
    }

    public override void Cancel(Booking booking)
    {
        booking.TransitionToState(new ClosedState("Order cancelled"));
    }

    public override void DatePassed(Booking booking)
    {
        booking.TransitionToState(new ClosedState("Booking expired"));
    }

    public override void EnterDetails(Booking booking, string attendee, int ticketCount)
    {
        booking.Attendee = attendee;
        booking.TicketCount = ticketCount;
        booking.TransitionToState(new PendingState());
    }
}