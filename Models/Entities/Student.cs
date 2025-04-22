using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string DateofBirth { get; set; }

        [Required]
        public string Specialized { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<StudentSubscription> StudentSubscriptions { get; set; }

        public User User { get; set; }
    }
}