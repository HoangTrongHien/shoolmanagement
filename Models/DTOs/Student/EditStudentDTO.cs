namespace SchoolManagement.Models.DTOs.Student;

public class EditStudentDTO
{
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Specialized { get; set; } = null!;
}