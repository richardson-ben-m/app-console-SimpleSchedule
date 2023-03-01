using Models;

namespace Logic.Storage;

public interface IReminderRepository
{
    Task Save(Reminder reminder);
}
