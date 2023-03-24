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

    /// <summary>
    /// Initializes the File that will be used for saving <see cref="Reminder"/>s.
    /// </summary>
    /// <param name="connectionString">The path of the file.</param>
    /// <exception cref="ApplicationException"></exception>
    public FileReminderRepository(string connectionString)
    {
        _fileInfo = new FileInfo(connectionString);

        var directory = _fileInfo.DirectoryName ?? throw new ApplicationException($"Reminder Repository File Path invalid: {connectionString}");
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        if (!_fileInfo.Exists)
            _fileInfo.Create();

        ConnectionString = _fileInfo.FullName;
    }

    /// <summary>
    /// Saves the <see cref="Reminder"/> to the file.
    /// </summary>
    /// <param name="reminder"></param>
    /// <returns></returns>
    public async Task Save(Reminder reminder)
    {
        var reminderString = JsonSerializer.Serialize(reminder);
        using StreamWriter file = new(_fileInfo.FullName, append: true);
        await file.WriteLineAsync(reminderString);
    }
}