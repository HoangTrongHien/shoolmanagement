using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class OnTeachClass
    {
        public int Id { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Required]
        public string Semester { get; set; }

        [Required]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }


        public ICollection<Attendance> Attendances { get; set; }

        public ICollection<StudentSubscription> StudentSubscriptions { get; set; }

        public ICollection<TeacherSubscription> TeacherSubscriptions { get; set; }

    }
}