using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolManagement.Models.Entities
{
    public class StudentAccount
    {
        [Key, ForeignKey("Student")]
        public int Id { get; set; }

        // [JsonIgnore]
        public Student Student { get; set; } = null!;

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }

}