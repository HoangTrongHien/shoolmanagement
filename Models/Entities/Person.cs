using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SchoolManagement.Models.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public DateTime DateofBirth { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Role { get; set; } = "Person";
        
        public Account Account { get; set; } = null!;

        public ICollection<Subscription> StudentSubscriptions { get; set; } = new List<Subscription>();
    }

}