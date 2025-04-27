using SchoolManagement.Models.DTOs.Person;
namespace SchoolManagement.Models.DTOs.Student;

public class CreateStudentWithAccountDTO : CreatePersonWithAccountDTO
{
    public string Specialized { get; set; } = null!;
}