namespace PatternsNotebook.Behavioral.State.BookingExample.BookingStates;

class BookedState : BookingState
{
    public override void EnterState(Booking booking)
    {
        Console.WriteLine("Booked, enjoy the event!");
    }

    public override void Cancel(Booking booking)
    {
        booking.TransitionToState(new ClosedState("Booking canceled with a refund"));  
    }

    public override void DatePassed(Booking booking)
    {
        booking.TransitionToState(new ClosedState("The event has already ended"));
    }

    public override void EnterDetails(Booking booking, string attendee, int ticketCount)
    {
    }
}