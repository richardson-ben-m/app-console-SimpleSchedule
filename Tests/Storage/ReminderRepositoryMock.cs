using Logic.Models;
using Logic.Storage;

namespace Tests.Storage
{
    internal class ReminderRepositoryMock : IReminderRepository
    {
        public ReminderDto? SavedReminder { get; private set; }
        public Task Save(ReminderDto reminder)
        {
            SavedReminder = reminder;
            return Task.CompletedTask;
        }
    }
}
