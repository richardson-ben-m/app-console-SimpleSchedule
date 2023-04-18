using Models;
using Storage;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tests.Storage;

internal class FileReminderRepositoryTests
{
    private string _fileName = "testfile.txt";
    private FileInfo? _fileInfo;
    private FileReminderRepository? _repository;
    
    #region Constructor

    [Test]
    public void Constructor_ValidConnectionStringInput_SetsConnectionStringProperty()
    {
        _fileInfo = new FileInfo(_fileName);
        _fileInfo.Create();

        _repository = new FileReminderRepository(_fileInfo.FullName);

        _repository.ConnectionString.Should().Be(_fileInfo.FullName);
    }

    [Test]
    public void Constructor_InvalidConnectionString_ThrowsApplicationException()
    {
        var invalidDrive = FindInvalidDrive();
        var wasThrown = false;
        try
        {
            _repository = new FileReminderRepository(invalidDrive);
        }
        catch (ApplicationException)
        {
            wasThrown = true;
        }
        wasThrown.Should().BeTrue($"path '{invalidDrive}' does not exist.");
    }

    [Test]
    public void Constructor_DirectoryDoesNotExist_DirectoryIsCreated()
    {
        var directoryString = "testDirectory";
        _fileName = $"{directoryString}\\{_fileName}";
        _fileInfo = new FileInfo(_fileName);
        var fullDirectoryPath = _fileInfo.DirectoryName;

        if (_fileInfo.Exists) _fileInfo.Delete();

        if (fullDirectoryPath != null && Directory.Exists(fullDirectoryPath))
            Directory.Delete(fullDirectoryPath);

        Directory.Exists(fullDirectoryPath).Should().BeFalse();

        _repository = new FileReminderRepository(_fileName);

        _fileInfo.Refresh();
        Directory.Exists(fullDirectoryPath).Should().BeTrue();
        _fileInfo.Exists.Should().BeTrue();

        DeleteTestFile();
        if (fullDirectoryPath != null && Directory.Exists(fullDirectoryPath))
            Directory.Delete(fullDirectoryPath);
    }

    [Test]
    public void Constructor_FileDoesNotExist_FileIsCreated()
    {
        _fileInfo = new FileInfo(_fileName);
        DeleteTestFile();
        _fileInfo = new FileInfo(_fileName);
        _fileInfo.Exists.Should().BeFalse();

        _repository = new FileReminderRepository(_fileInfo.FullName);

        _fileInfo.Refresh();
        _fileInfo.Exists.Should().BeTrue();
    }

    #endregion

    #region Save
    [Test]
    public async Task Save_AppendsReminderToFile()
    {
        _fileInfo = new FileInfo(_fileName);
        _repository = new FileReminderRepository(_fileInfo.FullName);
        var startLength = GetFileLength();
        var reminder = new Reminder("testTile", new TimeSpan(1));

        await _repository.Save(reminder);

        var endLength = GetFileLength();
        endLength.Should().BeGreaterThan(startLength);
    }

    private int GetFileLength()
    {
        if (_fileInfo == null || !_fileInfo.Exists) return 0;
        using StreamReader sr = new(_fileInfo.FullName);
        return sr.ReadToEnd().Length;
    }
    #endregion

    [TearDown]
    public void TearDown()
    {
        DeleteTestFile();
    }

    private static string FindInvalidDrive()
    {
        var drive = 'A';

        while (drive <= 'Z')
        {
            var path = $"{drive}:\\";

            var dir = new DirectoryInfo(path);
            if (!dir.Exists) return path;

            drive = (char)(Convert.ToUInt16(drive) + 1);
        }
        Assert.Fail("No Invalid Drive found! Unable to run test.");
        return "";
    }

    private void DeleteTestFile()
    {
        _repository = null;

        GC.Collect();
        GC.WaitForPendingFinalizers();

        if (_fileInfo != null && _fileInfo.Exists)
        {
            _fileInfo.Delete();
        }

        _fileInfo = null;
    }
}
