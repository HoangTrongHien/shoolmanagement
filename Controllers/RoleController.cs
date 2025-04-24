using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Models.DTOs;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    public RoleController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetAllRoles()
    {
        return Ok(_dbContext.Roles.ToList());
    }

    [HttpPost]
    public IActionResult CreateRole(CreateRoleDTO obj)
    {
        Role role = new Role{
            Name = obj.Name
        };

        _dbContext.Roles.Add(role);
        _dbContext.SaveChanges();

        return Ok(role);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IActionResult UpdateRole(int id, CreateRoleDTO obj)
    {
        var role = _dbContext.Roles.Find(id);

        if (role == null)
        {
            return NotFound("Can not find role");
        }

        role.Name = obj.Name;

        _dbContext.Roles.Update(role);
        _dbContext.SaveChanges();

        return Ok(role);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteRole(int id)
    {
        var role = _dbContext.Roles.Find(id);

        if (role == null)
        {
            return NotFound("Can not find role");
        }

        _dbContext.Roles.Remove(role);
        _dbContext.SaveChanges();
        return Ok(role);
    }

}