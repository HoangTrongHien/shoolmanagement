using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Models.DTOs;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    public StudentController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get the list of all student
    /// </summary>
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var students = _dbContext.Students.ToList();

        var studentDtos = students.Select(student => new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Specialized = student.Specialized,
            Phone = student.Phone,
            Email = student.Email,
        }).ToList();
        
        return Ok(studentDtos);
    }

    /// <summary>
    /// Get student by the ID
    /// </summary>
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetStudentById(int id)
    {
        var student = _dbContext.Students.Find(id);

        if (student == null)
        {
            return NotFound($"Student with ID {id} is not found");
        }

        return Ok(new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Specialized = student.Specialized,
            Phone = student.Phone,
            Email = student.Email,
        });
    }

    /// <summary>
    /// Create student without init student account
    /// </summary>
    [HttpPost]
    public IActionResult CreateStudent(CreateStudentDTO obj)
    {
        Student student = new Student(){
            Name = obj.Name,
            DateofBirth = obj.DateofBirth,
            Specialized = obj.Specialized,
            Phone = obj.Phone,
            Email = obj.Email,
        };

        try
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }
        catch (System.Exception)
        {
            return NotFound("Can not create student");            
        }
        
        // return CreatedAtAction(nameof(GetStudentById), new {id = student.Id}, student);
        return Ok(new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Specialized = student.Specialized,
            Phone = student.Phone,
            Email = student.Email,
        });
    }

    /// <summary>
    /// Create student within init student account
    /// </summary>
    [HttpPost("CreateStudentWithAccount")]
    public IActionResult CreateStudentWithAccount(CreateStudentWithAccountDTO obj)
    {
        Student student = new Student()
        {
            Name = obj.Name,
            DateofBirth = obj.DateofBirth,
            Specialized = obj.Specialized,
            Phone = obj.Phone,
            Email = obj.Email,
        };

        try
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }
        catch (System.Exception)
        {
            return NotFound("Can not create student before create student account");            
        }

        StudentAccount sa = new StudentAccount()
        {
            Id = student.Id,
            Username = obj.Username,
            Password = obj.Password,
            Student = student,
        };
        try
        {
            _dbContext.StudentAccounts.Add(sa);
            _dbContext.SaveChanges();
        }
        catch (System.Exception)
        {
            return NotFound("Student created but can not create student account");            
        }
        
        return Ok(new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Specialized = student.Specialized,
            Phone = student.Phone,
            Email = student.Email,
            Username = sa.Username,
        });
    }

    /// <summary>
    /// Edit student by Id
    /// </summary>
    [HttpPut]
    [Route("{id:int}")]
    public IActionResult EditStudent(int id, EditStudentDTO obj)
    {
        var student = _dbContext.Students.Find(id);

        if (student == null)
        {
            return NotFound("Can not find student to edit");
        }

        student.Name = obj.Name;
        student.DateofBirth = obj.DateofBirth;
        student.Email = obj.Email;
        student.Phone = obj.Phone;
        student.Specialized = obj.Specialized;

        try{
            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
        }catch{
            return NotFound("Can not Edit Student");
        }

        return Ok(new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Specialized = student.Specialized,
            Phone = student.Phone,
            Email = student.Email,
        });
    }

    /// <summary>
    /// Delete student by Id
    /// </summary>
    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = _dbContext.Students.Find(id);

        if (student == null)
        {
            return NotFound("Can not find student to delete");
        }
        try
        {
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }
        catch (System.Exception)
        {
            return NotFound("Can not delete student");           
        }

        return Ok(new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Specialized = student.Specialized,
            Phone = student.Phone,
            Email = student.Email,
        });
    }
}