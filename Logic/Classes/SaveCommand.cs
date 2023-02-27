using Logic.Interfaces;
using Models;

namespace Logic.Classes;

public class SaveCommandOptions
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public int DaysUntilReminder { get; set; }

    public SaveCommandOptions(string title, int daysUntilReminder)
    {
        Title = title;
        DaysUntilReminder = daysUntilReminder;
    }
}

public class SaveCommand : ICommand
{
    public Schedule Execute(SaveCommandOptions options)
    {
        return new Schedule(options.Title) { Description = options.Description };
    }
}
