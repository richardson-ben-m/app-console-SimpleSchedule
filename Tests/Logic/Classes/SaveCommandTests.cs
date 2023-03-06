using Logic.Classes;
using Models;
using Tests.Input;
using Tests.Output;
using Tests.Storage;

namespace Tests.Logic.Classes;

public class SaveCommandTests
{
    private ReminderRepositoryMock _repository;
    private SaveCommand _saveCommandUnderTest;

    [SetUp]
    public void SetUp()
    {
        _repository = new ReminderRepositoryMock();
        _saveCommandUnderTest = new SaveCommand(_repository);
    }


    [TestCase("test title", "test description", 1)]
    [TestCase("reminder", "don't forget", 100)]
    [TestCase("this too", null, 5)]
    public void Execute_SavesAndReturnsAReminder(string title, string? description, int reminderOffset)
    {
        var reminderTimeSpan = new TimeSpan(days: reminderOffset, 0, 0, 0);
        var expected = new Reminder(title, reminderTimeSpan) { Description= description };

        var result = _saveCommandUnderTest.Execute(new SaveCommandOptions(title, reminderTimeSpan) { Description = description });

        expected.IsEquivalent(result).Should().BeTrue();
        _repository.SavedReminder.Should().Be(result);
    }

    [Test]
    public void GetOptionsFromUser_RequestsUserInput()
    {
        var title = "test title";
        var description = "test description";
        var timeSpanUnits = "hours";
        var timeSpanValue = "1";
        var timeSpan = new TimeSpan(1, 0, 0);

        var expected = new SaveCommandOptions(title, timeSpan) { Description = description };

        var outputHandler = new OutputHandlerMock();
        var inputHandler = new UserInputHandlerMock();

        var callback = (string outString) => 
        {
            if (outString == null) return;
            if (outString.Contains("Title") && !outString.Contains("again"))
                inputHandler.ReadLineResponse = title;
            else if (outString.Contains("Description"))
                inputHandler.ReadLineResponse = description;
            else if (outString.Contains("hours, days") && !outString.Contains("again"))
                inputHandler.ReadLineResponse = timeSpanUnits;
            else if (outString.Contains("Number"))
                inputHandler.ReadLineResponse = timeSpanValue;
        };
        outputHandler.OutputLineOfTextCallback = callback;

        var result = _saveCommandUnderTest.GetOptionsFromUser(outputHandler, inputHandler);

        result.Should().BeEquivalentTo(expected);
    }

}
