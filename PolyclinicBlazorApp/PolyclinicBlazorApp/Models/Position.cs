using System;
using System.Collections.Generic;

namespace PolyclinicBlazorApp.Models;

public partial class Position
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<AdmissionTicket> AdmissionTickets { get; set; } = new List<AdmissionTicket>();

    public virtual ICollection<DoctorsPosition> DoctorsPositions { get; set; } = new List<DoctorsPosition>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
