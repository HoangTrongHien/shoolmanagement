using SchoolManagement.Models.DTOs.Person;
namespace SchoolManagement.Models.DTOs;

public class CreateTeacherWithAccountDTO : CreatePersonWithAccountDTO
{
    public string Department { get; set; } = null!;
}