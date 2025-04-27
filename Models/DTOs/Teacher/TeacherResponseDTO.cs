using SchoolManagement.Models.DTOs.Person;
namespace SchoolManagement.Models.DTOs.Teacher;

public class TeacherResponseDTO : PersonResponseDTO
{
    public string Department { get; set; } = null!;
}