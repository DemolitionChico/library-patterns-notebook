using PatternsNotebook.Behavioral.State.BookingExample.BookingStates;

namespace PatternsNotebook.Behavioral.State.BookingExample;

public class Booking
{
    public string? Attendee { get; set; }
    public int TicketCount { get; set; }
    public int BookingId { get; set; }

    private BookingState _currentState = null!;

    public void TransitionToState(BookingState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }

    public Booking()
    {
        BookingId = new Random().Next();
        TransitionToState(new NewState());
    }

    public void SubmitDetails(string attendee, int ticketCount)
    {
        _currentState.EnterDetails(this, attendee, ticketCount);
    }

    public void Cancel()
    {
        _currentState.Cancel(this);
    }

    public void DatePassed()
    {
        _currentState.DatePassed(this);
    }
}