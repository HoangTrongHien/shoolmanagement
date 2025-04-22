using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class Teacher
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateofBirth { get; set; }

        [Required]
        public string Specialized { get; set; }

        public string Phone { get; set; }

        public int UserId { get; set; } //TODO

        public ICollection<TeacherSubscription> TeacherSubscriptions { get; set; }

        public TeacherAccount TeacherAccount { get; set; }
    }
}