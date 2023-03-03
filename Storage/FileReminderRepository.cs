using Logic.Storage;
using Models;
using System.Text.Json;

namespace Storage;

internal class FileReminderRepository : IReminderRepository
{
    /// <summary>
    /// In the FileReminderRepository, this is the file path that Reminders will be stored in.
    /// </summary>
    public string ConnectionString { get; }
    private readonly FileInfo _fileInfo;

    public FileReminderRepository(string connectionString)
    {
        _fileInfo = new FileInfo(connectionString);
        if (_fileInfo == null)
            throw new ApplicationException($"Reminder Repository File Path invalid: {connectionString}");

        var directory = _fileInfo.DirectoryName ?? throw new ApplicationException($"Reminder Repository File Path invalid: {connectionString}");
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        if (!_fileInfo.Exists)
            _fileInfo.Create();

        ConnectionString = _fileInfo.FullName;
    }

    public async Task Save(Reminder reminder)
    {
        var reminderString = JsonSerializer.Serialize(reminder);
        using StreamWriter file = new(_fileInfo.FullName, append: true);
        await file.WriteLineAsync(reminderString);
    }
}