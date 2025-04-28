namespace SchoolManagement.Models.DTOs.Person;

public class EditPersonDTO
{
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
}