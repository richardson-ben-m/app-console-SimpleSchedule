using Logic.Models;
using Models;

namespace Logic.Interfaces;

public interface IReminderCommandService
{
    /// <summary>
    /// Saves the given <see cref="ReminderCommandDto"/> to Storage.
    /// </summary>
    void SaveReminder(Reminder reminder);
}
