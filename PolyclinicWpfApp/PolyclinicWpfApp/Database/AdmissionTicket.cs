//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PolyclinicWpfApp.Database
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

    public partial class AdmissionTicket
    {
        public int id { get; set; }
        public Nullable<int> patientId { get; set; }
        public Nullable<int> specialistId { get; set; }
        public Nullable<System.DateTime> receiptDate { get; set; }
        public string complaints { get; set; }
        public Nullable<int> cabinet { get; set; }
        public Nullable<int> doctorPositionId { get; set; }
        public Nullable<int> currentStateId { get; set; }
        public string appointmentResult { get; set; }
        public DateTime ShortDate
        {
            get
            {
                DateTime shortDate = (DateTime)receiptDate;
                return shortDate.Date;
            }
        }

        public SolidColorBrush entryElementStateColor
        {
            get
            {
                if (currentStateId == 1)
                    return new SolidColorBrush(Color.FromArgb(255, 78, 223, 222));
                else
                    return new SolidColorBrush(Color.FromArgb(255, 13, 150, 155));
            }
        }

        public string DoctorWithSpeciality
        {
            get
            {
                try
                {
                    return Position.title + " " + User1.FullName;
                }
                catch
                {
                    return "Не определено";
                }
            }
        }


        public virtual TicketState TicketState { get; set; }
        public virtual Position Position { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
