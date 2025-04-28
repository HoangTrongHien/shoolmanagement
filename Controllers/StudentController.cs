using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models.DTOs.Student;
using SchoolManagement.Models.Entities;
using SchoolManagement.Repositories;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public StudentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _unitOfWork.Students.GetAllWithAccountAsync();

        var studentDtos = students.Select(student => new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Phone = student.Phone,
            Email = student.Email,
            Specialized = student.Specialized,
            Username = student.Account?.Username
        });
        return Ok(studentDtos);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _unitOfWork.Students.GetByIdWithAccountAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return Ok(new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Phone = student.Phone,
            Email = student.Email,
            Specialized = student.Specialized,
            Username = student.Account?.Username
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentDTO obj)
    {
        Student student = new Student{
            Name = obj.Name,
            DateofBirth = obj.DateofBirth,
            Phone = obj.Phone,
            Email = obj.Email,
            Specialized = obj.Specialized,
            Role = "Student",
        };
        await _unitOfWork.Students.AddAsync(student);
        await _unitOfWork.CompleteAsync();
        return Ok(student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EditStudentDTO updated)
    {
        var student = await _unitOfWork.Students.GetByIdWithAccountAsync(id);
        if (student == null) return NotFound();

        student.Name = updated.Name;
        student.DateofBirth = updated.DateofBirth;
        student.Phone = updated.Phone;
        student.Email = updated.Email;
        student.Specialized = updated.Specialized;

        _unitOfWork.Students.Update(student);
        await _unitOfWork.CompleteAsync();
        return Ok(new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Phone = student.Phone,
            Email = student.Email,
            Specialized = student.Specialized,
            Username = student.Account?.Username
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _unitOfWork.Students.GetByIdWithAccountAsync(id);
        if (student == null) return NotFound();

        _unitOfWork.Students.Delete(student);
        await _unitOfWork.CompleteAsync();
        return Ok(new StudentResponseDTO{
            Id = student.Id,
            Name = student.Name,
            DateofBirth = student.DateofBirth,
            Phone = student.Phone,
            Email = student.Email,
            Specialized = student.Specialized,
            Username = student.Account?.Username
        });
    }
}