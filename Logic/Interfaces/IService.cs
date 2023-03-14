using Logic.Models;
using Models;

namespace Logic.Interfaces;

public interface IService
{
    /// <summary>
    /// Saves the given <see cref="ReminderDto"/> to Storage.
    /// </summary>
    void SaveReminder(Reminder reminder);
}
