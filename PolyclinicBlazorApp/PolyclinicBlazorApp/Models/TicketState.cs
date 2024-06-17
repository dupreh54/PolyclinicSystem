using System;
using System.Collections.Generic;

namespace PolyclinicBlazorApp.Models;

public partial class TicketState
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<AdmissionTicket> AdmissionTickets { get; set; } = new List<AdmissionTicket>();
}
