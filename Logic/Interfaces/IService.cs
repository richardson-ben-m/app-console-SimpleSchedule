using Logic.Models;

namespace Logic.Interfaces;

public interface IService
{
    /// <summary>
    /// Creates a <see cref="Reminder"/> from the given <see cref="ReminderDto"/> and saves it to Storage.
    /// </summary>
    void SaveReminder(ReminderDto reminder);
}
