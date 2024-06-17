using System;
using System.Collections.Generic;

namespace PolyclinicBlazorApp.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? Cabinet { get; set; }

    public DateTime? TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public TimeSpan AppointmentTime { get; set; }

    public int? PositionId { get; set; }

    public DateTime JustDate
    {
        get
        {
            DateTime dateTime = (DateTime)TimeStart;
            return dateTime.Date;
        }
    }

    public TimeSpan JustTime
    {
        get
        {
            DateTime dateTime = (DateTime)TimeStart;
            TimeSpan timeSpan = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
            return timeSpan;
        }
    }

    public virtual Position? Position { get; set; }

    public virtual User? User { get; set; }
}
