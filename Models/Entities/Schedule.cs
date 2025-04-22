using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        [Required]
        public int ScheduleInformationId { get; set; }

        public ICollection<ScheduleInformation> ScheduleInformations { get; set; }
        public ICollection<OnTeachClass> OnTeachClasses { get; set; }
    }
}