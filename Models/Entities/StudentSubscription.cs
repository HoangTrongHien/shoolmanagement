using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class StudentSubscription
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int OnTeachClassId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}