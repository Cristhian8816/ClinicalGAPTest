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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=LAPTOP-E3OD0JS8\\SQLEXPRESS;Initial Catalog=Makelup;    user id=desenv;password=desenv; MultipleActiveResultSets=true; Persist Security Info=True;");
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-E3OD0JS8\\SQLEXPRESS;Initial Catalog=ClinicalGAPDB; user id=desenv;password=desenv; MultipleActiveResultSets=true; Persist Security Info=True;");

                //optionsBuilder.UseSqlServer("Data Source=SQL5059.site4now.net;Initial Catalog=DB_A5E858_Makelup;User Id=DB_A5E858_Makelup_admin;Password=40A39j21c14a11l;");
                //optionsBuilder.UseSqlServer("Data Source = LAPTOP - E3OD0JS8\\SQLEXPRESS; Initial Catalog = ClinicalGAPDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;");

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
        }
    }
}
