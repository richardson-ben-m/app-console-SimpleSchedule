using Models;

namespace Logic.Storage;

public interface IReminderRepository
{

    /// <summary>
    /// Saves the <see cref="Reminder"/> to storage.
    /// </summary>
    /// <param name="reminder"></param>
    /// <returns></returns>
    Task Save(Reminder reminder);
}
