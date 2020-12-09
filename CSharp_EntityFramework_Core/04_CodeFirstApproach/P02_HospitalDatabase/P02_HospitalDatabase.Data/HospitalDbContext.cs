using Microsoft.EntityFrameworkCore;

using P02_HospitalDatabase.Data.Models;

namespace P02_HospitalDatabase.Data
{
    public partial class HospitalDbContext : DbContext
    {
        public HospitalDbContext()
        {

        }

        public HospitalDbContext(DbContextOptions dbContextOptions)
            : base (dbContextOptions)
        {

        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(p => p.Email)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new {pm.Patientid, pm.MedicamentId});

                entity.HasOne(pm => pm.Patient)
                      .WithMany(p => p.Prescriptions)
                      .HasForeignKey(pm => pm.Patientid);

                entity.HasOne(pm => pm.Medicament)
                      .WithMany(m => m.Prescriptions)
                      .HasForeignKey(pm => pm.MedicamentId);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
