using P01_StudentSystem.Models;

using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data
{
    public partial class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(s => s.Name)
                      .IsRequired(true)
                      .IsUnicode(true)
                      .HasMaxLength(100);

                entity.Property(s => s.PhoneNumber)
                      .IsRequired(false)
                      .IsUnicode(false);

                entity.Property(s => s.RegisteredOn)
                      .IsRequired(true);

                entity.Property(s => s.Birthday)
                      .IsRequired(false);

            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity.Property(c => c.Name)
                      .IsRequired(true)
                      .IsUnicode(true)
                      .HasMaxLength(80);

                entity.Property(c => c.Description)
                      .IsRequired(false)
                      .IsUnicode(true);

                entity.Property(c => c.StartDate)
                      .IsRequired(true);

                entity.Property(c => c.EndDate)
                      .IsRequired(true);


                entity.Property(c => c.Price)
                      .IsRequired(true);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity.Property(c => c.Name)
                      .IsRequired(true)
                      .IsUnicode(true)
                      .HasMaxLength(50);

                entity.Property(r => r.Url)
                      .IsUnicode(false);

                entity.Property(r => r.ResourceType)
                      .IsRequired(true);

                entity.Property(r => r.CourseId)
                      .IsRequired(true);

                entity.HasOne(r => r.Course)
                      .WithMany(c => c.Resources)
                      .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.ToTable("HomeworkSubmissions");

                entity.HasKey(h => h.HomeworkId);

                entity.Property(h => h.Content)
                      .IsUnicode(false)
                      .IsRequired(true);

                entity.Property(h => h.ContentType)
                      .IsRequired(true);

                entity.Property(h => h.SubmissionTime)
                      .IsRequired(true);

                entity.Property(h => h.StudentId)
                      .IsRequired(true);

                entity.Property(h => h.CourseId)
                      .IsRequired(true);

                entity.HasOne(h => h.Student)
                      .WithMany(s => s.HomeworkSubmissions)
                      .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                      .WithMany(c => c.HomeworkSubmissions)
                      .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.CourseEnrollments)
                      .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                      .WithMany(c => c.StudentsEnrolled)
                      .HasForeignKey(sc => sc.CourseId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
