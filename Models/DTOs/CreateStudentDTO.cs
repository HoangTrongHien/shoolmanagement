namespace SchoolManagement.Models.DTOs;

public class CreateStudentDTO
{
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Specialized { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;

}