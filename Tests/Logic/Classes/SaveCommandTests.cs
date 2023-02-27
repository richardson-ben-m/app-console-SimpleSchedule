using Logic.Classes;
using Models;

namespace Tests.Logic.Classes;

public class SaveCommandTests
{

    [TestCase("test title", "test description", 0)]
    [TestCase("reminder", "don't forget", 1)]
    public void ExecuteSavesASchedule(string title, string description, int daysDiff)
    {
        var options = new SaveCommandOptions(title, daysDiff) { Description = description };
        var command = new SaveCommand();

        var result = command.Execute(options);

        result.Should()
            .NotBeNull().And
            .BeAssignableTo<Schedule>();
        var schedule = result as Schedule;

        schedule.Title.Should().Be(title);
        schedule.Description.Should().Be(description);

        var resultDiff = schedule.EndDate - schedule.CreatedDate;
        resultDiff.Days.Should().Be(daysDiff);

    }
}
