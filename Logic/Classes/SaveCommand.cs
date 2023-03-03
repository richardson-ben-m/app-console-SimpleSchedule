using Logic.Input;
using Logic.Interfaces;
using Logic.Output;
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
{
    private readonly IReminderRepository _repository;

    public SaveCommand(IReminderRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Requests the user to enter Reminder options to save.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public SaveCommandOptions GetOptionsFromUser(OutputHandlerBase outputHandler, UserInputHandlerBase inputHandler)
    {
        throw new NotImplementedException();
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
