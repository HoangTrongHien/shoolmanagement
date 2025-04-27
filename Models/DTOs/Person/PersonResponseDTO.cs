namespace SchoolManagement.Models.DTOs.Person;

public class PersonResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;

    public string? Username { get; set; }
}
