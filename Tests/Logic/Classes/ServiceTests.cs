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

    //[TestCase("title1", "description1", )]
    //public void SaveReminder_SavesValidReminders(string title, string description, string timeUnits, int timePeriod)
    //{
    //    var reminder = new ReminderDto();
    //    _service.SaveReminder(reminder);
    //    _repository.SavedReminder.Should().Be(reminder);
    //}

    //private static object[] TryParseValidTestCases =
    //{
    //    new ReminderDto() {Title = "Title1", Description = "Description1", RemindIn = new TimeSpan()}
    //}
}
