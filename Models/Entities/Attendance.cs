namespace SchoolManagement.Models.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        public int OnTeachClassId { get; set; }

        public int StudentSubscriptionId { get; set; }

        public int TeacherSubscriptionId { get; set; }

        public int OccurDate { get; set; }
        
        public OnTeachClass OnTeachClass { get; set; }
    }
}