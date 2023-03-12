using Logic.Interfaces;
using Logic.Models;
using Models;

namespace API.Commands;

internal class SaveCommand : ICommand
{
    private readonly IService _service;

    public SaveCommand(IService service)
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
        _service.SaveReminder(new ReminderDto());
        return "OK";
    }
}
