namespace SchoolManagement.Models.DTOs.Account;

public class CreateAccountDTO
{
    public int AccountId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}