using SchoolManagement.Models.DTOs.Person;
namespace SchoolManagement.Models.DTOs.Teacher;

public class EditTeacherDTO : EditPersonDTO
{
    public string Department { get; set; } = null!;
}