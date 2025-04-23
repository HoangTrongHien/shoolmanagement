using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        public int OnTeachClassId { get; set; }
        public OnTeachClass OnTeachClass { get; set; } = null!;

        public int StudentSubscriptionId { get; set; }
        public StudentSubscription StudentSubscription { get; set; } = null!;


        public int TeacherSubscriptionId { get; set; }
        public TeacherSubscription TeacherSubscription { get; set; } = null!;

        public int OccurDate { get; set; }
        
    }
}