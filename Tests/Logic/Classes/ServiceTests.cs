using Logic.Classes;
using Logic.Models;
using System.Text.Json;
using Tests.Storage;

namespace Tests.Logic.Classes;

internal class ServiceTests
{
    private ReminderRepositoryMock _repository;
    private Service _service;

    [SetUp]
    public void SetUp()
    {
        _repository = new ReminderRepositoryMock();
        _service = new Service(_repository);
    }

    [Test]
    public void SaveReminder_Runs_SavesReminder()
    {
        var reminder = new ReminderDto();
        _service.SaveReminder(reminder);
        _repository.SavedReminder.Should().Be(reminder);
    }
}
