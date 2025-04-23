namespace SchoolManagement.Models.DTOs;

public class CreateStudentAccountDTO
{
    public int StudentId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}