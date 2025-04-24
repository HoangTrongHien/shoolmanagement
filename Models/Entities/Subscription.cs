using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        [Required]
        public int OnTeachClassId { get; set; }
        public OnTeachClass OnTeachClass { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<Attendance> Attendances { get; set; } = null!;
    }
}