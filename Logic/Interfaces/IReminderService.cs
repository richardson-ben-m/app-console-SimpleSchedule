using Logic.Models;
using Models;

namespace Logic.Interfaces;

public interface IReminderService
{
    /// <summary>
    /// Saves the given <see cref="ReminderDto"/> to Storage.
    /// </summary>
    void SaveReminder(Reminder reminder);
}
