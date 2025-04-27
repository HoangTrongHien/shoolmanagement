using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models.DTOs;
using SchoolManagement.Models.DTOs.Teacher;
using SchoolManagement.Models.Entities;
using SchoolManagement.Repositories;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    protected readonly IUnitOfWork _unitOfWork;
    public TeacherController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teachers = await _unitOfWork.Teachers.GetAllWithAccountAsync();

        var teacherDtos = teachers.Select(teacher => new TeacherResponseDTO{
            Id = teacher.Id,
            Name = teacher.Name,
            DateofBirth = teacher.DateofBirth,
            Phone = teacher.Phone,
            Email = teacher.Email,
            Department = teacher.Department,
            Username = teacher.Account?.Username
        });

        return Ok(teacherDtos);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var teacher = await _unitOfWork.Teachers.GetByIdWithAccountAsync(id);

        if (teacher == null)
        {
            return NotFound();
        }
        return Ok(new TeacherResponseDTO{
            Id = teacher.Id,
            Name = teacher.Name,
            DateofBirth = teacher.DateofBirth,
            Phone = teacher.Phone,
            Email = teacher.Email,
            Department = teacher.Department,
            Username = teacher.Account?.Username
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTeacherDTO obj)
    {
        Teacher teacher = new Teacher{
            Name = obj.Name,
            DateofBirth = obj.DateofBirth,
            Email = obj.Email,
            Phone = obj.Phone,
            Department = obj.Department,
            Role = "Teacher",
        };

        await _unitOfWork.Teachers.AddAsync(teacher);
        await _unitOfWork.CompleteAsync();

        return Ok(new TeacherResponseDTO{
            Id = teacher.Id,
            Name = teacher.Name,
            DateofBirth = teacher.DateofBirth,
            Phone = teacher.Phone,
            Email = teacher.Email,
            Department = teacher.Department,
            Username = teacher.Account?.Username
        });
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(int id, EditTeacherDTO updated)
    {
        var teacher = await _unitOfWork.Teachers.GetByIdWithAccountAsync(id);

        if (teacher == null) return NotFound();

        teacher.Name = updated.Name;
        teacher.DateofBirth = updated.DateofBirth;
        teacher.Phone = updated.Phone;
        teacher.Email = updated.Email;
        teacher.Department = updated.Department;

        _unitOfWork.Teachers.Update(teacher);
        await _unitOfWork.CompleteAsync();

        return Ok(new TeacherResponseDTO{
            Id = teacher.Id,
            Name = teacher.Name,
            DateofBirth = teacher.DateofBirth,
            Phone = teacher.Phone,
            Email = teacher.Email,
            Department = teacher.Department,
            Username = teacher.Account?.Username
        });
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var teacher = await _unitOfWork.Teachers.GetByIdWithAccountAsync(id);
        if (teacher == null) return NotFound();

        _unitOfWork.Teachers.Delete(teacher);
        await _unitOfWork.CompleteAsync();

        return Ok(new TeacherResponseDTO{
            Id = teacher.Id,
            Name = teacher.Name,
            DateofBirth = teacher.DateofBirth,
            Phone = teacher.Phone,
            Email = teacher.Email,
            Department = teacher.Department,
            Username = teacher.Account?.Username
        });
    }
}