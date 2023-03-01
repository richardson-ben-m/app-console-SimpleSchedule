using Logic.Storage;
using Models;

namespace Tests.Storage
{
    internal class ReminderRepositoryMock : IReminderRepository
    {
        public Reminder? SavedReminder { get; private set; }
        public Task Save(Reminder reminder)
        {
            SavedReminder = reminder;
            return Task.CompletedTask;
        }
    }
}
