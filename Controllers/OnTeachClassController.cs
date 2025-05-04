using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models.DTOs.OnTeachClass;
using SchoolManagement.Models.Entities;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Controllers;

[ApiController]
[Route("api/onteachclass")]
public class OnTeachClassController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public OnTeachClassController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unitOfWork.OnTeachClasses.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOnTeachClassDTO createObj)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(createObj.SubjectId);

        OnTeachClass obj = new OnTeachClass{
            SubjectId = createObj.SubjectId,
            Subject = subject,
            Semester = createObj.Semester,
            ScheduleId = createObj.ScheduleId,
        };

        await _unitOfWork.OnTeachClasses.AddAsync(obj);
        await _unitOfWork.CompleteAsync();

        return Ok(new OnTeachClassResponse{
            SubjectId = obj.SubjectId,
            Semester = obj.Semester,
            ScheduleId = obj.ScheduleId,
        });
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(int id, EditOnTeachClassDTO editObj)
    {
        var obj = await _unitOfWork.OnTeachClasses.GetByIdAsync(id);

        if (obj == null)
        {
            return NotFound("Can not file obj for update");
        }

        obj.ScheduleId = editObj.ScheduleId;
        obj.Semester = editObj.Semester;
        obj.SubjectId = editObj.SubjectId;

        _unitOfWork.OnTeachClasses.Update(obj);
        await _unitOfWork.CompleteAsync();

        return Ok(new OnTeachClassResponse{
            ScheduleId = obj.ScheduleId,
            Semester = obj.Semester,
            SubjectId = obj.SubjectId
        });
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id){
        var obj = await _unitOfWork.OnTeachClasses.GetByIdAsync(id);

        if (obj == null)
        {
            return NotFound("Can not found on teach class to delete");
        }

        _unitOfWork.OnTeachClasses.Delete(obj);
        await _unitOfWork.CompleteAsync();

        return Ok(obj);
    }

}