using SchoolManagement.Models.DTOs.Person;
namespace SchoolManagement.Models.DTOs.Student;

public class CreateStudentDTO : CreatePersonDTO
{
    public string Specialized { get; set; } = null!;
}