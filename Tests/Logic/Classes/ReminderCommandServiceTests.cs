using Logic.Classes;
using Models;
using Tests.Storage.Mocks;

namespace Tests.Logic.Classes;

internal class ReminderCommandServiceTests
{
    private ReminderRepositoryMock _repository;
    private ReminderCommandService _service;

    [SetUp]
    public void SetUp()
    {
        _repository = new ReminderRepositoryMock();
        _service = new ReminderCommandService(_repository);
    }

    [Test]
    public void SaveReminder_SavesAReminder()
    {
        var reminder = new Reminder("test title", new TimeSpan(1, 0, 0));
        _service.SaveReminder(reminder);
        _repository.SavedReminder.Should().Be(reminder);
    }
}
