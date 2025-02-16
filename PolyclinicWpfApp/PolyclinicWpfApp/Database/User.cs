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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.AdmissionTicket = new HashSet<AdmissionTicket>();
            this.AdmissionTicket1 = new HashSet<AdmissionTicket>();
            this.DoctorsPosition = new HashSet<DoctorsPosition>();
            this.Schedule = new HashSet<Schedule>();
        }
    
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> userRoleId { get; set; }
        public string medicalPolicy { get; set; }
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }

        public string FullName { get { return surname + " " + name + " " + patronymic; } }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdmissionTicket> AdmissionTicket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdmissionTicket> AdmissionTicket1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorsPosition> DoctorsPosition { get; set; }
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
