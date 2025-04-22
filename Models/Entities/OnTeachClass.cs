using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class OnTeachClass
    {
        public int Id { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public string Semester { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        public ICollection<StudentSubscription> StudentSubscriptions { get; set; }
    }
}