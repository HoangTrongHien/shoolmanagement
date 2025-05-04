namespace SchoolManagement.Models.DTOs.OnTeachClass;

public class OnTeachClassResponse
{
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string Semester { get; set; } = null!;
        public int ScheduleId { get; set; }
}