using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.Entities
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public ICollection<ScheduleInformation> ScheduleInformations { get; set; } = null!;
        public ICollection<OnTeachClass> OnTeachClasses { get; set; } = null!;
    }
}