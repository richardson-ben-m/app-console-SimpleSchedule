namespace Models;

/// <summary>
/// The Reminder business object
/// </summary>
public class Reminder
{
    public string Title { get; private set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Reminder(string title, TimeSpan reminderTimeSpan)
    {
        Title = title;
        StartDate = DateTime.Now;
        EndDate = StartDate.Add(reminderTimeSpan);
    }

    public override bool Equals(object? obj)
    {
        return obj is Reminder reminder &&
            Title == reminder.Title &&
            Description == reminder.Description &&
            StartDate == reminder.StartDate && 
            EndDate == reminder.EndDate;
    }

    public bool IsEquivalent(object? obj)
    {
        return obj is Reminder reminder &&
            Title == reminder.Title &&
            Description == reminder.Description &&
            EndDate - StartDate == reminder.EndDate - reminder.StartDate;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Description, StartDate, EndDate);
    }
}
