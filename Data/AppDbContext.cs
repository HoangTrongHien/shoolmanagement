using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Data
{
    public class AppDbContext: DbContext{      
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<OnTeachClass> OnTeachClasses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleInformation> ScheduleInformations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("Role")
                .HasValue<Person>("Person")
                .HasValue<Student>("Student")
                .HasValue<Teacher>("Teacher");
                
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

            modelBuilder.Entity<Subscription>()
                .HasOne(a => a.Account)
                .WithMany(d => d.Subscriptions)
                .HasForeignKey(a => a.AccountId);

            modelBuilder.Entity<Subscription>()
                .HasOne(a => a.OnTeachClass)
                .WithMany(d => d.Subscriptions)
                .HasForeignKey(a => a.OnTeachClassId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Subscription)
                .WithMany(d => d.Attendances)
                .HasForeignKey(a => a.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.OnTeachClass)
                .WithMany(d => d.Attendances)
                .HasForeignKey(a => a.OnTeachClassId);

            modelBuilder.Entity<Subscription>()
                .HasOne(a => a.OnTeachClass)
                .WithMany(d => d.Subscriptions)
                .HasForeignKey(a => a.OnTeachClassId);

            modelBuilder.Entity<Subscription>()
                .HasOne(a => a.Account)
                .WithMany(d => d.Subscriptions)
                .HasForeignKey(a => a.AccountId);

            modelBuilder.Entity<Person>()
                .HasOne(s => s.Account)
                .WithOne(sa => sa.Person)
                .HasForeignKey<Account>(sa => sa.Id);

        }
    }
}