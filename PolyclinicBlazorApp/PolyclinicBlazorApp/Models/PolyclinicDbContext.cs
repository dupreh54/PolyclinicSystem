using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PolyclinicBlazorApp.Models;

public partial class PolyclinicDbContext : DbContext
{
    private static PolyclinicDbContext instance;

    public static PolyclinicDbContext GetContext()
    {
        if(instance == null)
            instance = new PolyclinicDbContext();
        return instance;
    }

    public PolyclinicDbContext()
    {
    }

    public PolyclinicDbContext(DbContextOptions<PolyclinicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdmissionTicket> AdmissionTickets { get; set; }

    public virtual DbSet<DoctorsPosition> DoctorsPositions { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<TicketState> TicketStates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DUPREHPC\\SQLEXPRESS; Trusted_Connection=True; Database=PolyclinicDB; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdmissionTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admissio__3213E83FDB6CC649");

            entity.ToTable("AdmissionTicket");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentResult).HasColumnName("appointmentResult");
            entity.Property(e => e.Cabinet).HasColumnName("cabinet");
            entity.Property(e => e.Complaints)
                .HasMaxLength(200)
                .HasColumnName("complaints");
            entity.Property(e => e.CurrentStateId).HasColumnName("currentStateId");
            entity.Property(e => e.DoctorPositionId).HasColumnName("doctorPositionId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.ReceiptDate)
                .HasColumnType("datetime")
                .HasColumnName("receiptDate");
            entity.Property(e => e.SpecialistId).HasColumnName("specialistId");

            entity.HasOne(d => d.CurrentState).WithMany(p => p.AdmissionTickets)
                .HasForeignKey(d => d.CurrentStateId)
                .HasConstraintName("FK__Admission__curre__4BAC3F29");

            entity.HasOne(d => d.DoctorPosition).WithMany(p => p.AdmissionTickets)
                .HasForeignKey(d => d.DoctorPositionId)
                .HasConstraintName("FK__Admission__docto__4AB81AF0");

            entity.HasOne(d => d.Patient).WithMany(p => p.AdmissionTicketPatients)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Admission__patie__48CFD27E");

            entity.HasOne(d => d.Specialist).WithMany(p => p.AdmissionTicketSpecialists)
                .HasForeignKey(d => d.SpecialistId)
                .HasConstraintName("FK__Admission__speci__49C3F6B7");
        });

        modelBuilder.Entity<DoctorsPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoctorsP__3213E83F966BAE03");

            entity.ToTable("DoctorsPosition");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PositionId).HasColumnName("positionId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Position).WithMany(p => p.DoctorsPositions)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__DoctorsPo__posit__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.DoctorsPositions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__DoctorsPo__userI__3F466844");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3213E83F518D0051");

            entity.ToTable("Position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3213E83FADD8AB9E");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3213E83F29B0103A");

            entity.ToTable("Schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentTime).HasColumnName("appointmentTime");
            entity.Property(e => e.Cabinet).HasColumnName("cabinet");
            entity.Property(e => e.PositionId).HasColumnName("positionId");
            entity.Property(e => e.TimeEnd)
                .HasColumnType("datetime")
                .HasColumnName("timeEnd");
            entity.Property(e => e.TimeStart)
                .HasColumnType("datetime")
                .HasColumnName("timeStart");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Position).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Schedule__positi__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Schedule__userId__4316F928");
        });

        modelBuilder.Entity<TicketState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TicketSt__3213E83F43E4DDCE");

            entity.ToTable("TicketState");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F7097A433");

            entity.ToTable("User");

            entity.HasIndex(e => e.Login, "UQ__User__7838F272CF82E5D9").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.MedicalPolicy)
                .HasMaxLength(16)
                .HasColumnName("medicalPolicy");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
            entity.Property(e => e.UserRoleId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("userRoleId");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .HasConstraintName("FK__User__userRoleId__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
