using Logic.Classes;
using Models;
using Tests.Storage;

namespace Tests.Logic.Classes;

public class SaveCommandTests
{
    [TestCase("test title", "test description", 1)]
    [TestCase("reminder", "don't forget", 100)]
    [TestCase("this too", null, 5)]
    public void ExecuteSavesAndReturnsAReminder(string title, string? description, int reminderOffset)
    {
        var reminderTimeSpan = new TimeSpan(days: reminderOffset, 0, 0, 0);
        var expected = new Reminder(title, reminderTimeSpan) { Description= description };
        var repository = new ReminderRepositoryMock();

        SaveCommand sc = new SaveCommand(repository);
        var result = new SaveCommand(repository).Execute(new SaveCommandOptions(title, reminderTimeSpan) { Description = description });

        expected.IsEquivalent(result).Should().BeTrue();
        repository.SavedReminder.Should().Be(result);
    }
}
