using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class ScheduleInformation
    {
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public string Address { get; set; }
    }
}