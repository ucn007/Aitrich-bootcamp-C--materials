using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using machinetest.Model;

namespace machinetest.Data;

public partial class MyDbContext: DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appoinment> Appoinments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=blazor-machinetest;User Id=sa;Password=Ullas@123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appoinment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appoinme__3213E83F1965B8C5");

            entity.ToTable("Appoinment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AppoinmentTime).HasDefaultValueSql("(CONVERT([time],getutcdate()))");
            entity.Property(e => e.AppointmentDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PatientName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appoinments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appoinmen__Docto__412EB0B6");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appoinments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appoinmen__patie__403A8C7D");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctor__3213E83F3F77FAFC");

            entity.ToTable("Doctor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Available)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient__3213E83F73244A67");

            entity.ToTable("Patient");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PatientName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F89DA9FB3");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(90)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
