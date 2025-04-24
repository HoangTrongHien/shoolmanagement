using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolManagement.Models.Entities
{
    public class Account
    {
        [Key, ForeignKey("Person")]
        public int Id { get; set; }

        // [JsonIgnore]
        public Person Person { get; set; } = null!;

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public ICollection<Subscription>? Subscriptions { get; set; }
    }

}