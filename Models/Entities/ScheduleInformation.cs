using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class ScheduleInformation
    {
        public int Id { get; set; }

        public int ScheduleId { get; set; } 
        public Schedule Schedule { get; set; } = null!;

        [Required]
        public DateTime Time { get; set; } 

        public string Address { get; set; } = null!;
    }
}