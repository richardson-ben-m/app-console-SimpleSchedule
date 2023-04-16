using Logic.Interfaces;
using Logic.Models;
using Models;

namespace API.Endpoints;

internal class SaveEndpoint : IEndpoint
{
    public static string Address => "save";

    private readonly IReminderCommandService _reminderService;

    public SaveEndpoint(IReminderCommandService service)
    {
        _reminderService = service;
    }

    /// <summary>
    /// Saves a <see cref="Reminder"/> to Storage.
    /// </summary>
    /// <param name="args">The <see cref="Reminder"/> to save, formatted as Json.</param>
    /// <returns>'OK' if save was successful. Otherwise, error details.</returns>
    public string CallEndpoint(string[] args)
    {
        try
        {
            if (!ReminderCommandDto.TryParse(args[0], out var dto))
                throw new ArgumentException("First argument must be a valid Reminder object.");
            _reminderService.SaveReminder(dto.ToReminder());
            return "OK";
        }
        catch (Exception e)
        {
            return $"Error: {e.Message}";
        }
    }
}
