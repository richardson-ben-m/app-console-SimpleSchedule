using Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Logic.Models;

public enum ReminderTimeUnits
{
    Hours,
    Days
}

public class ReminderDto
{
    public string Title { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }
    public ReminderTimeUnits RemindInUnits { get; set; }
    public ushort RemindInValue { get; set; }

    public ReminderDto()
    {
        Title = string.Empty;
    }

    public static bool TryParse(string? json, out ReminderDto result)
    {
        result = new ReminderDto();

        if (string.IsNullOrEmpty(json)) return false;

        ReminderDto? dto;

        try
        {
            dto = JsonSerializer.Deserialize<ReminderDto>(json, new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } });
        }
        catch (Exception)
        {
            return false;
        }
        
        if (dto == null) return false;
        if (dto.Title == string.Empty) return false;
        if (dto.RemindInValue == 0) return false;

        result = dto;
        return true;
    }

    public Reminder ToReminder()
    {
        var timeSpan = RemindInUnits switch
        {
            ReminderTimeUnits.Hours => new TimeSpan(RemindInValue, 0, 0),
            ReminderTimeUnits.Days => new TimeSpan(RemindInValue, 0, 0, 0),
            _ => throw new ArgumentException("Reminder TimeSpan Units are not valid."),
        };
        return new Reminder(Title, timeSpan) { Description = Description };
    }

    /// <summary>
    /// Overrides ToString method, returns object as Json string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var options = new JsonSerializerOptions 
        { 
            Converters = { new JsonStringEnumConverter() }
        };
        return JsonSerializer.Serialize(this, options);
    }
}
