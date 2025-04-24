using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        public int OnTeachClassId { get; set; }
        public OnTeachClass OnTeachClass { get; set; } = null!;

        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; } = null!;
        public int OccurDate { get; set; }
        
    }
}