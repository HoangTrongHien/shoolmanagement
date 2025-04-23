using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        // [JsonIgnore]
        public TeacherAccount TeacherAccount { get; set; } = null!;

        public ICollection<TeacherSubscription> TeacherSubscriptions { get; set; } = null!;

    }
}