using SchoolManagement.Models.DTOs.Person;
namespace SchoolManagement.Models.DTOs;

public class CreateTeacherDTO : CreatePersonDTO
{
    public string Department { get; set; } = null!;
}