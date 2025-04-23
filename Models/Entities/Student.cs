using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SchoolManagement.Models.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string DateofBirth { get; set; } = null!;

        [Required]
        public string Specialized { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public StudentAccount StudentAccount { get; set; } = null!;

        public ICollection<StudentSubscription> StudentSubscriptions { get; set; } = new List<StudentSubscription>();
    }

}