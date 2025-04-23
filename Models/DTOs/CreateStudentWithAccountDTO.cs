public class CreateStudentWithAccountDTO
{
    public string Name { get; set; } = null!;
    public DateTime DateofBirth { get; set; }
    public string Specialized { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
