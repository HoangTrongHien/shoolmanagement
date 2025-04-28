using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models.DTOs.Subject;
using SchoolManagement.Models.Entities;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/subject")]
public class SubjectController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public SubjectController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subjects = await _unitOfWork.Subjects.GetAllAsync();

        var subjectResponseDtos = subjects.Select(subject => new SubjectResponseDTO{
            Id = subject.Id,
            Name = subject.Name,
            Description = subject.Description
        });
        return Ok(subjectResponseDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSubjectDTO obj)
    {
        Subject subject = new Subject{
            Name = obj.Name,
            Description = obj.Description
        };

        await _unitOfWork.Subjects.AddAsync(subject);
        await _unitOfWork.CompleteAsync();

        return Ok(new SubjectResponseDTO{
            Name = subject.Name,
            Description = subject.Description
        });
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(int id, CreateSubjectDTO obj)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(id);

        if (subject == null)
        {
            return NotFound("Can not file subject for update");
        }

        subject.Name = obj.Name;
        subject.Description = obj.Description;

        _unitOfWork.Subjects.Update(subject);
        await _unitOfWork.CompleteAsync();
        return Ok(new SubjectResponseDTO{
            Id = subject.Id,
            Name = subject.Name,
            Description = subject.Description
        });
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id){
        var subject = await _unitOfWork.Subjects.GetByIdAsync(id);

        if (subject == null)
        {
            return NotFound("Can not found subject to delete");
        }

        _unitOfWork.Subjects.Delete(subject);
        await _unitOfWork.CompleteAsync();

        return Ok(subject);
    }
}