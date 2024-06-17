using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace PolyclinicBlazorApp.Models;

public partial class AdmissionTicket
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public int? SpecialistId { get; set; }

    public DateTime? ReceiptDate { get; set; }

    public string? Complaints { get; set; }

    public int? Cabinet { get; set; }

    public int? DoctorPositionId { get; set; }

    public int? CurrentStateId { get; set; }

    public string? AppointmentResult { get; set; }

    public string DoctorWithSpeciality
    {
        get
        {
            try
            {
                Position position = PolyclinicDbContext.GetContext().Positions.Where(p => p.Id == DoctorPositionId).First();
                User doctor = PolyclinicDbContext.GetContext().Users.Where(u => u.Id == SpecialistId).First();

                return position.Title + " " + doctor.FullName;
            }
            catch
            {
                return "Не определено";
            }
        }
    }

    public string CurrentStateTitle { get
        {
            return PolyclinicDbContext.GetContext().TicketStates.Where(t => t.Id == CurrentStateId).FirstOrDefault().Title;
        } }


    public virtual TicketState? CurrentState { get; set; }

    public virtual Position? DoctorPosition { get; set; }

    public virtual User? Patient { get; set; }

    public virtual User? Specialist { get; set; }
}
