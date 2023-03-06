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
        outputHandler.OutputLineOfText("Saving a Reminder:");

        var title = GetTitle(outputHandler, inputHandler);
        var description = GetDescription(outputHandler, inputHandler);
        var timeSpanUnits = GetTimeSpanUnits(outputHandler, inputHandler);
        var timeSpanValue = GetTimeSpan(timeSpanUnits, outputHandler, inputHandler);

        TimeSpan timeSpan;
        if (timeSpanUnits == "hours")
            timeSpan = new TimeSpan(timeSpanValue, 0, 0);
        else
            timeSpan = new TimeSpan(timeSpanValue, 0, 0, 0);

        return new SaveCommandOptions(title, timeSpan) { Description = description};
    }

    private static string GetTitle(OutputHandlerBase outputHandler, UserInputHandlerBase inputHandler)
    {
        outputHandler.OutputLineOfText("Title (required)? ");
        var title = inputHandler.ReadLine();
        if (title != null) return title;

        outputHandler.OutputLineOfText("Title is Required! Try again.");
        return GetTitle(outputHandler, inputHandler);
    }

    private static string? GetDescription(OutputHandlerBase outputHandler, UserInputHandlerBase inputHandler)
    {
        outputHandler.OutputLineOfText("Description (optional)? ");
        return inputHandler.ReadLine();
    }

    private static string GetTimeSpanUnits(OutputHandlerBase outputHandler, UserInputHandlerBase inputHandler)
    {
        outputHandler.OutputLineOfText("Time unit to be reminded in (hours, days)? ");
        var timeSpanInput = inputHandler.ReadLine();
        var timeSpanUnit = timeSpanInput?.ToLowerInvariant();
        if (timeSpanUnit == "hours" || timeSpanUnit == "days")
            return timeSpanUnit;

        outputHandler.OutputLineOfText("Time Unit valid values are: hours, days. Please try again.");
        return GetTimeSpanUnits(outputHandler, inputHandler);
    }

    private static int GetTimeSpan(string timeSpanUnits, OutputHandlerBase outputHandler, UserInputHandlerBase inputHandler)
    {
        outputHandler.OutputLineOfText($"Number of {timeSpanUnits} to be reminded in? ");
        var timeSpanText = inputHandler.ReadLine();
        var validTimeSpan = int.TryParse(timeSpanText, out var timeSpan);
        if (validTimeSpan) return timeSpan;

        outputHandler.OutputLineOfText("Valid Time Span value is an integer. Please try again.");
        return GetTimeSpan(timeSpanUnits, outputHandler, inputHandler);
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
