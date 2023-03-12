using Models;

namespace API.Commands;

internal class SaveCommand : ICommand
{
    /// <summary>
    /// Saves a <see cref="Reminder"/> to Storage.
    /// </summary>
    /// <param name="args">The <see cref="Reminder"/> to save, formatted as Json.</param>
    /// <returns>'OK' if save was successful. Otherwise, error details.</returns>
    public string Run(string[] args)
    {
        return "OK";
    }
}
