using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Models.DTOs;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentAccountController : ControllerBase
{
    private readonly AppDbContext _dbcontext;

    public StudentAccountController(AppDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    /// <summary>
    /// Gets the list of all student account
    /// </summary>
    [HttpGet]
    public IActionResult GetAllStudentAccounts()
    {
        var studentAccounts = _dbcontext.StudentAccounts.ToList();
        
        var studentAccountDtos = studentAccounts.Select(studentAccount => new StudentAccountResponseDTO{
            Id = studentAccount.Id,
            Username = studentAccount.Username,
        }).ToList();
        return Ok(studentAccountDtos);
    }

    /// <summary>
    /// Gets student account by the ID
    /// </summary>
    [HttpGet]
    [Route("id:int")]
    public IActionResult GetStudentAccountById(int id)
    {
        var studentAccount = _dbcontext.StudentAccounts.Find(id);

        if (studentAccount == null)
        {
            return NotFound($"Student Account with ID {id} is not found");
        }

        return Ok(new StudentAccountResponseDTO{
            Id = studentAccount.Id,
            Username = studentAccount.Username,
        });
    }

    /// <summary>
    /// Create student account
    /// </summary>
    [HttpPost]
    public IActionResult CreateStudentAccount(CreateStudentAccountDTO obj){

        var student = _dbcontext.Students.Find(obj.StudentId);

        if (student == null)
        {
            return NotFound($"Student with ID {obj.StudentId} not found");
        }

        var existingAccount = _dbcontext.StudentAccounts.Find(obj.StudentId);

        if (existingAccount != null)
        {
            return NotFound("This student already has an account");
        }


        StudentAccount studentAccount = new StudentAccount()
        {
            Id = obj.StudentId,
            Username = obj.Username,
            Password = obj.Password,
            Student = student
        };

        try
        {
            _dbcontext.StudentAccounts.Add(studentAccount);
            _dbcontext.SaveChanges();
        }
        catch (System.Exception)
        {
            
            return NotFound("Can not update new information for this Student Account");
        }
        

        return Ok(new StudentAccountResponseDTO{
            Id = studentAccount.Id,
            Username = studentAccount.Username,
        });
    }

    /// <summary>
    /// Update student account by the ID
    /// </summary>
    [HttpPut]
    [Route("{id:int}")]
    public IActionResult UpdateStudentAccount(int id, UpdateStudentAccountDTO obj)
    {
        var studentAccount = _dbcontext.StudentAccounts.Find(id);

        if (studentAccount == null)
        {
            return NotFound($"Student Account with ID {id} not found");
        }

        studentAccount.Username = obj.Username;
        studentAccount.Password = obj.Password;

        _dbcontext.StudentAccounts.Add(studentAccount);
        _dbcontext.SaveChanges();

        return Ok(new StudentAccountResponseDTO{
            Id = studentAccount.Id,
            Username = studentAccount.Username,
        });
    }

    /// <summary>
    /// Delete student account by the ID
    /// </summary>
    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteStudentAccount(int id)
    {
        var studentAccount = _dbcontext.StudentAccounts.Find(id);

        if (studentAccount == null){
            return NotFound("This student account doesn't exist");
        }

        try
        {
            _dbcontext.StudentAccounts.Remove(studentAccount);
            _dbcontext.SaveChanges();
        }
        catch (System.Exception)
        {
            return NotFound("Can not delete this student account!");
        }

        return Ok(new StudentAccountResponseDTO{
            Id = studentAccount.Id,
            Username = studentAccount.Username,
        });
    }
}

