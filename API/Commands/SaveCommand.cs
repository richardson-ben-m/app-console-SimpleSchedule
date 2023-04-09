using Logic.Interfaces;
using Logic.Models;
using Models;

namespace API.Commands;

internal class SaveCommand : ICommand
{
    public static string CommandWord => "save";

    private readonly IReminderService _service;

    public SaveCommand(IReminderService service)
    {
        _service = service;
    }

    /// <summary>
    /// Saves a <see cref="Reminder"/> to Storage.
    /// </summary>
    /// <param name="args">The <see cref="Reminder"/> to save, formatted as Json.</param>
    /// <returns>'OK' if save was successful. Otherwise, error details.</returns>
    public string Run(string[] args)
    {
        try
        {
            if (!ReminderDto.TryParse(args[0], out var dto)) 
                throw new ArgumentException("First argument must be a valid Reminder object.");
            _service.SaveReminder(dto.ToReminder());
            return "OK";
        }
        catch (Exception e)
        {
            return $"Error: {e.Message}";
        }
    }
}
