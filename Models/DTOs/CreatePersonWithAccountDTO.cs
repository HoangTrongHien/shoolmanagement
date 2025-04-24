namespace SchoolManagement.Models.DTOs;

public class CreatePersonWithAccountDTO
{
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Specialized { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int RoleId { get; set; }

    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
