namespace SchoolManagement.Models.DTOs.OnTeachClass;

public class CreateOnTeachClassDTO
{
    public int SubjectId { get; set; }
    public string Semester { get; set; } = null!;
    public int ScheduleId { get; set; }
}
