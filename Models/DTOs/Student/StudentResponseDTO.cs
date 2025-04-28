namespace SchoolManagement.Models.DTOs.Student;

public class StudentResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Username { get; set; }
    public string Specialized { get; set; } = null!;
}