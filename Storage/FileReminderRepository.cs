using Logic.Storage;
using Models;

namespace Storage
{
    internal class FileReminderRepository : IReminderRepository
    {
        /// <summary>
        /// In the FileReminderRepository, this is the file path that Reminders will be stored in.
        /// </summary>
        public string ConnectionString { get; }

        public FileReminderRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public Task Save(Reminder reminder)
        {
            // TODO: Open a connection to the file at ConnectionString, add this Reminder to it.
            return Task.CompletedTask;
        }
    }
}