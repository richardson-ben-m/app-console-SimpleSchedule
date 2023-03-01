using Logic.Interfaces;
using Models;

namespace Logic.Classes;

public class SaveCommandOptions
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public TimeSpan ReminderTimeSpan { get; set; }

    public SaveCommandOptions(string title, TimeSpan reminderTimeSpan)
    {
        Title = title;
        ReminderTimeSpan = reminderTimeSpan;
    }
}

public class SaveCommand : ICommand
{
    public Reminder Execute(SaveCommandOptions options)
    {
        return new Reminder(options.Title, options.ReminderTimeSpan) { Description = options.Description };
    }
}
