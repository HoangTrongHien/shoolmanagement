namespace SchoolManagement.Models.DTOs.Teacher;

public class TeacherResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Username { get; set; }
    public string Department { get; set; } = null!;
}