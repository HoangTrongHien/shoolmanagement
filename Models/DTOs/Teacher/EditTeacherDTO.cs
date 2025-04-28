namespace SchoolManagement.Models.DTOs.Teacher;

public class EditTeacherDTO
{
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Department { get; set; } = null!;
}