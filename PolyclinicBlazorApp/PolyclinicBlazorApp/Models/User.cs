using System;
using System.Collections.Generic;

namespace PolyclinicBlazorApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? UserRoleId { get; set; }

    public string? MedicalPolicy { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public string FullName
    {
        get
        {
            return Surname + " " + Name + " " + Patronymic;
        }
    }

    public virtual ICollection<AdmissionTicket> AdmissionTicketPatients { get; set; } = new List<AdmissionTicket>();

    public virtual ICollection<AdmissionTicket> AdmissionTicketSpecialists { get; set; } = new List<AdmissionTicket>();

    public virtual ICollection<DoctorsPosition> DoctorsPositions { get; set; } = new List<DoctorsPosition>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Role? UserRole { get; set; }
}
