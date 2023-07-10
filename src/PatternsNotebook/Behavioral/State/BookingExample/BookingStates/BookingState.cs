namespace PatternsNotebook.Behavioral.State.BookingExample.BookingStates;

public abstract class BookingState
{
    public abstract void EnterState(Booking booking);
    public abstract void Cancel(Booking booking);
    public abstract void DatePassed(Booking booking);
    public abstract void EnterDetails(Booking booking, string attendee, int ticketCount);
}