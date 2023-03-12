using System.Text.Json;

namespace Logic.Models;

public class ReminderDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public TimeSpan RemindIn { get; set; }

    public ReminderDto()
    {
        Title = string.Empty;
    }

    public ReminderDto(string? json)
    {
        if (json == null) throw new ArgumentException("Enter a Reminder to save.");
        var dto = JsonSerializer.Deserialize<ReminderDto>(json) ?? throw new ArgumentException("Not a valid Reminder.");
        Title = dto.Title;
        Description = dto.Description;
        RemindIn = dto.RemindIn;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
