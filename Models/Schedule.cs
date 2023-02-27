using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

/// <summary>
/// The Schedule business object
/// </summary>
public class Schedule
{
    public string Title { get; set; }

    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime EndDate { get; set; }

    public Schedule(string title)
    {
        Title = title;
    }
}
