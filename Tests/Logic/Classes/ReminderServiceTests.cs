using Logic.Classes;
using Models;
using Tests.Storage.Mocks;

namespace Tests.Logic.Classes;

internal class ReminderServiceTests
{
    private ReminderRepositoryMock _repository;
    private ReminderService _service;

    [SetUp]
    public void SetUp()
    {
        _repository = new ReminderRepositoryMock();
        _service = new ReminderService(_repository);
    }

    [Test]
    public void SaveReminder_SavesAReminder()
    {
        var reminder = new Reminder("test title", new TimeSpan(1, 0, 0));
        _service.SaveReminder(reminder);
        _repository.SavedReminder.Should().Be(reminder);
    }
}
