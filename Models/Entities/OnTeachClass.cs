using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class OnTeachClass
    {
        public int Id { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;

        [Required]
        public string Semester { get; set; } = null!;

        [Required]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;


        public ICollection<Attendance> Attendances { get; set; } = null!;

        public ICollection<Subscription> Subscriptions { get; set; } = null!;
    }
}