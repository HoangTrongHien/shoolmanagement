namespace SchoolManagement.Models.DTOs;

public class EditPersonDTO
{
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Specialized { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int RoleId { get; set; }

}