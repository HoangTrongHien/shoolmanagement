using SchoolManagement.Models.DTOs.Person;
namespace SchoolManagement.Models.DTOs.Student;

public class StudentResponseDTO : PersonResponseDTO
{
    public string Specialized { get; set; } = null!;
}