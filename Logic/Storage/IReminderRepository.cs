using Logic.Models;

namespace Logic.Storage;

public interface IReminderRepository
{

    /// <summary>
    /// Saves the <see cref="ReminderDto"/> to storage.
    /// </summary>
    /// <param name="reminder"></param>
    /// <returns></returns>
    Task Save(ReminderDto reminder);
}
