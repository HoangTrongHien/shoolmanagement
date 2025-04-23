using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public DateTime DateofBirth { get; set; }

        [Required]
        public string Specialized { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public TeacherAccount TeacherAccount { get; set; } = null!;

        public ICollection<TeacherSubscription> TeacherSubscriptions { get; set; } = null!;

    }
}