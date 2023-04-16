using Logic.Models;
using Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tests.Logic.Models;

internal class ReminderCommandDtoTests
{
    #region TryParse
    private static readonly string[] TryParseValidTestCases =
    {
        new ReminderCommandDto() {Title = "Title1", Description = "Description1", RemindInUnits = ReminderTimeUnits.Hours, RemindInValue = 1}.ToString(),
        new ReminderCommandDto() {Title = "Title2", RemindInUnits = ReminderTimeUnits.Hours, RemindInValue = 2}.ToString(),
        new ReminderCommandDto() {Title = "Title3", Description = "Description3", RemindInUnits = ReminderTimeUnits.Days, RemindInValue = 3 }.ToString(),
        new ReminderCommandDto() {Title = "Title4", RemindInUnits = ReminderTimeUnits.Days, RemindInValue = 4}.ToString(),
    };

    [TestCaseSource(nameof(TryParseValidTestCases))]
    public void TryParse_ReceivesValidJson_ReturnsObjectAndTrue(string validJson)
    {
        var expected = JsonSerializer.Deserialize<ReminderCommandDto>(validJson, new JsonSerializerOptions { Converters = {new JsonStringEnumConverter()}})
            ?? throw new ArgumentException($"Test case has an error, does not convert to {typeof(ReminderCommandDto)}. Test case value: {validJson}");

        var pass = ReminderCommandDto.TryParse(validJson, out var result);

        pass.Should().BeTrue("the string is valid Json for a ReminderDto.");
        result.Title.Should().Be(expected.Title, "the title was set");
        result.Description.Should().Be(expected.Description, "the description was set");
        result.RemindInUnits.Should().Be(expected.RemindInUnits, "the reminder timespan units was set");
        result.RemindInValue.Should().Be(expected.RemindInValue, "the reminder timespan value was set");
    }


    private static readonly string[] TryParseInvalidTestCases =
    {
        // title is required
        new ReminderCommandDto() {Title = "", RemindInUnits = ReminderTimeUnits.Hours, RemindInValue = 1}.ToString(),
        new ReminderCommandDto() {RemindInUnits = ReminderTimeUnits.Hours, RemindInValue = 1}.ToString(),
    
        // time span must be valid
        //// Invalid test. RemindInUnits default is Hours, which is valid.
        //new ReminderDto() { Title = "a title", RemindInValue = 1 }.ToString(),
        new ReminderCommandDto() { Title = "a title", RemindInUnits = ReminderTimeUnits.Hours }.ToString(),
        new ReminderCommandDto() { Title = "a title", RemindInUnits = ReminderTimeUnits.Hours }.ToString().Replace("Hours","units"),
        new ReminderCommandDto() { Title = "a title" }.ToString(),
    
        // time span must be > 0
        new ReminderCommandDto() { Title = "a title", RemindInUnits = ReminderTimeUnits.Hours, RemindInValue = 0 }.ToString(),
        new ReminderCommandDto() { Title = "a title", RemindInUnits = ReminderTimeUnits.Hours, RemindInValue = 0 }.ToString().Replace("0","-1"),
    
        // string must be able to convert to valid object
        "not a valid ReminderDto"
    };

    [TestCaseSource(nameof(TryParseInvalidTestCases))]
    public void TryParse_ReceivesInvalidJson_ReturnsDefaultObjectAndFalse(string invalidJson)
    {
        var pass = ReminderCommandDto.TryParse(invalidJson, out var result);

        pass.Should().BeFalse("the string is not valid Json for a ReminderDto.");
        result.Title.Should().Be(new ReminderCommandDto().Title, "the Title has default value.");
        result.Description.Should().Be(new ReminderCommandDto().Description, "the Description has default value.");
        result.RemindInUnits.Should().Be(new ReminderCommandDto().RemindInUnits, "the timespan units has default value.");
        result.RemindInValue.Should().Be(new ReminderCommandDto().RemindInValue, "the timespan value has default value.");
    }
    #endregion

    #region ToReminder

    [Test]
    public void ToReminder_ReturnsReminderWithDtoValues()
    {
        var dto = new ReminderCommandDto
        {
            Title = "test title",
            Description = "test description",
            RemindInUnits = ReminderTimeUnits.Days,
            RemindInValue = 1
        };

        var result = dto.ToReminder();

        result.Should().NotBeNull().And.BeAssignableTo<Reminder>();
        result.Title.Should().Be(dto.Title);
        result.Description.Should().Be(dto.Description);

        var timeDiff = result.EndDate - result.StartDate;
        timeDiff.Days.Should().Be(dto.RemindInValue);
    }

    #endregion
}
