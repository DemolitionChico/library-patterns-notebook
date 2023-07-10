namespace PatternsNotebook.Behavioral.State.BookingExample.BookingStates;

class PendingState : BookingState
{
    private bool _isCancelled = false;
    
    public override void EnterState(Booking booking)
    {
        Console.WriteLine("> Entering pending state");
        ProcessBooking(booking);
    }

    private void ProcessBooking(Booking booking)
    {
        // some processing operations
        if (_isCancelled)
        {
            booking.TransitionToState(new BookedState());
        }
        else
        {
            booking.TransitionToState(new ClosedState("Processing canceled"));
        }
    }

    public override void Cancel(Booking booking)
    {
        _isCancelled = true;
    }

    public override void DatePassed(Booking booking)
    {
        Console.WriteLine("Invalid action, booking processing");
    }

    public override void EnterDetails(Booking booking, string attendee, int ticketCount)
    {
        Console.WriteLine("Invalid action, booking processing");
    }
}