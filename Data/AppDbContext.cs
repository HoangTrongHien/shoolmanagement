using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Data
{
    public class AppDbContext: DbContext{      
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<OnTeachClass> OnTeachClasses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleInformation> ScheduleInformations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAccount> StudentAccounts { get; set; }
        public DbSet<StudentSubscription> StudentSubscriptions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAccount> TeacherAccounts { get; set; }
        public DbSet<TeacherSubscription> TeacherSubscriptions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OnTeachClass>()
                .HasOne(a => a.Subject)
                .WithMany(d => d.OnTeachClasses)
                .HasForeignKey(a => a.SubjectId);

            modelBuilder.Entity<OnTeachClass>()
                .HasOne(a => a.Schedule)
                .WithMany(d => d.OnTeachClasses)
                .HasForeignKey(a => a.ScheduleId);

            modelBuilder.Entity<ScheduleInformation>()
                .HasOne(a => a.Schedule)
                .WithMany(d => d.ScheduleInformations)
                .HasForeignKey(a => a.ScheduleId);

            modelBuilder.Entity<TeacherSubscription>()
                .HasOne(a => a.Teacher)
                .WithMany(d => d.TeacherSubscriptions)
                .HasForeignKey(a => a.TeacherId);

            modelBuilder.Entity<TeacherSubscription>()
                .HasOne(a => a.OnTeachClass)
                .WithMany(d => d.TeacherSubscriptions)
                .HasForeignKey(a => a.OnTeachClassId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.TeacherSubscription)
                .WithMany(d => d.Attendances)
                .HasForeignKey(a => a.TeacherSubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.OnTeachClass)
                .WithMany(d => d.Attendances)
                .HasForeignKey(a => a.OnTeachClassId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.StudentSubscription)
                .WithMany(d => d.Attendances)
                .HasForeignKey(a => a.StudentSubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentSubscription>()
                .HasOne(a => a.OnTeachClass)
                .WithMany(d => d.StudentSubscriptions)
                .HasForeignKey(a => a.OnTeachClassId);

            modelBuilder.Entity<StudentSubscription>()
                .HasOne(a => a.Student)
                .WithMany(d => d.StudentSubscriptions)
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.StudentAccount)
                .WithOne(sa => sa.Student)
                .HasForeignKey<StudentAccount>(sa => sa.Id);
            
            modelBuilder.Entity<Teacher>()
                .HasOne(s => s.TeacherAccount)
                .WithOne(sa => sa.Teacher)
                .HasForeignKey<TeacherAccount>(sa => sa.Id);

        }
    }
}