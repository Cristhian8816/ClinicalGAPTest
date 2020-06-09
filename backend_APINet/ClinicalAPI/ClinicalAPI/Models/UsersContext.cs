using System;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata;
namespace ClinicalAPI.Models
{
    public partial class UsersContext : DbContext
    {
        public UsersContext()
        {
        }

        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //LocalConexionString
                //optionsBuilder.UseSqlServer("Data Source=LAPTOP-E3OD0JS8\\SQLEXPRESS;Initial Catalog=ClinicalGAPDB; user id=desenv;password=desenv; MultipleActiveResultSets=true; Persist Security Info=True;");
                //SmarterConexionString
                optionsBuilder.UseSqlServer("Data Source = SQL5059.site4now.net; Initial Catalog = DB_A5E858_ClinicalGAP; User Id = DB_A5E858_ClinicalGAP_admin; Password = 40A39j21c14a11l;");                
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("Patients");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PhoneNumber");

                entity.Property(e => e.Address)
                    .HasColumnName("Address");               
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId);

                entity.ToTable("Appoiments");

                entity.Property(e => e.AppointmentId)
                    .HasColumnName("AppoitmentId")
                    .ValueGeneratedNever();

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AppointmentType)
                    .HasColumnName("AppointmentType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("Date");               
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("MigrationsHistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnName("MigrationId")
                    .HasMaxLength(250)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ProductVersion)
                    .HasColumnName("ProductVersion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
