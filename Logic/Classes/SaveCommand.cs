using Logic.Interfaces;
using Logic.Storage;
using Models;

namespace Logic.Classes;

/// <summary>
/// DTO for saving a Reminder to the repository
/// </summary>
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

/// <summary>
/// Command object for saving a Reminder to the repository
/// </summary>
public class SaveCommand : ICommand
//public class SaveCommand : ICommand<SaveCommandOptions, Reminder>
{
    private readonly IReminderRepository _repository;

    public SaveCommand(IReminderRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Method to save a <see cref="Reminder"/> to the repository
    /// </summary>
    /// <param name="options"></param>
    /// <returns>The saved Reminder</returns>
    public Reminder Execute(SaveCommandOptions options)
    {
        var reminder = new Reminder(options.Title, options.ReminderTimeSpan) { Description = options.Description };
        _repository.Save(reminder);
        return reminder;
    }
}
