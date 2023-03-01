using Logic.Classes;
using Models;

namespace Tests.Logic.Classes;

public class SaveCommandTests
{
    [TestCase("test title", "test description", 0)]
    [TestCase("reminder", "don't forget", 1)]
    public void ExecuteSavesASchedule(string title, string description, int reminderOffset)
    {
        var reminderTimeSpan = new TimeSpan(days: reminderOffset, 0, 0, 0);
        var expected = new Reminder(title, reminderTimeSpan) { Description= description };

        var result = new SaveCommand().Execute(new SaveCommandOptions(title, reminderTimeSpan) { Description = description });

        expected.IsEquivalent(result).Should().BeTrue();

    }
}
