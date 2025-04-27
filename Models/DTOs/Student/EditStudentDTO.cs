using SchoolManagement.Models.DTOs.Person;
namespace SchoolManagement.Models.DTOs.Student;

public class EditStudentDTO : EditPersonDTO
{
    public string Specialized { get; set; } = null!;
}