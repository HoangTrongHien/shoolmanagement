using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolManagement.Models.Entities
{
    public class TeacherAccount
    {
        [Key, ForeignKey("Teacher")]
        public int Id { get; set; }

        // [JsonIgnore]
        public Teacher Teacher { get; set; } = null!;

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}