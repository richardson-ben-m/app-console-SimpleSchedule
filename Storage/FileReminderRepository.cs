using System.IO;
using Logic.Storage;
using Models;

namespace Storage;

internal class FileReminderRepository : IReminderRepository
{
    /// <summary>
    /// In the FileReminderRepository, this is the file path that Reminders will be stored in.
    /// </summary>
    public string ConnectionString { get; }
    private FileInfo _fileInfo;

    public FileReminderRepository(string connectionString)
    {
        _fileInfo = new FileInfo(connectionString);
        if (_fileInfo == null)
            throw new ApplicationException($"Reminder Repository File Path invalid: {connectionString}");

        var directory = _fileInfo.DirectoryName;
        if (directory == null)
            throw new ApplicationException($"Reminder Repository File Path invalid: {connectionString}");

        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        if (!_fileInfo.Exists)
            _fileInfo.Create();

        ConnectionString = _fileInfo.FullName;
    }

    public Task Save(Reminder reminder)
    {
        // TODO: Open a connection to the file at ConnectionString, add this Reminder to it.
        return Task.CompletedTask;
    }
}