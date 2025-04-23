using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }


        public ICollection<ScheduleInformation> ScheduleInformations { get; set; } = null!;
        public ICollection<OnTeachClass> OnTeachClasses { get; set; } = null!;
    }
}