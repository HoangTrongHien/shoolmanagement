using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Models.DTOs;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    public PersonController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get the list of all persons
    /// </summary>
    [HttpGet]
    public IActionResult GetAllPersons()
    {
        var persons = _dbContext.Persons.ToList();

        var personDtos = persons.Select(person => new PersonResponseDTO{
            Id = person.Id,
            Name = person.Name,
            DateofBirth = person.DateofBirth,
            Phone = person.Phone,
            Email = person.Email,
        }).ToList();
        
        return Ok(personDtos);
    }

    /// <summary>
    /// Get person by the ID
    /// </summary>
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetPersonById(int id)
    {
        var person = _dbContext.Persons.Find(id);

        if (person == null)
        {
            return NotFound($"person with ID {id} is not found");
        }

        return Ok(new PersonResponseDTO{
            Id = person.Id,
            Name = person.Name,
            DateofBirth = person.DateofBirth,
            Phone = person.Phone,
            RoleId = person.RoleId,
            Email = person.Email,
        });
    }

    /// <summary>
    /// Create person without init account
    /// </summary>
    [HttpPost]
    public IActionResult CreatePerson(CreatePersonDTO obj)
    {
        Person person = new Person(){
            Name = obj.Name,
            DateofBirth = obj.DateofBirth,
            Phone = obj.Phone,
            Email = obj.Email,
            RoleId = obj.RoleId,
        };

        try
        {
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
        }
        catch (System.Exception e)
        {
            return NotFound($"Can not create person, {e}");            
        }
        
        return Ok(new PersonResponseDTO{
            Id = person.Id,
            Name = person.Name,
            DateofBirth = person.DateofBirth,
            Phone = person.Phone,
            Email = person.Email,
            RoleId = person.RoleId
        });
    }

    /// <summary>
    /// Create person within init account
    /// </summary>
    [HttpPost("CreatePersonWithAccount")]
    public IActionResult CreatePersonWithAccount(CreatePersonWithAccountDTO obj)
    {
        Person person = new Person()
        {
            Name = obj.Name,
            DateofBirth = obj.DateofBirth,
            Phone = obj.Phone,
            Email = obj.Email,
            RoleId = obj.RoleId,
        };

        try
        {
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
        }
        catch (System.Exception)
        {
            return NotFound("Can not create person before create person account");            
        }

        Account account = new Account()
        {
            Id = person.Id,
            Username = obj.Username,
            Password = obj.Password,
            Person = person,
        };
        try
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }
        catch (System.Exception)
        {
            return NotFound("person created but can not create person account");            
        }
        
        return Ok(new PersonResponseDTO{
            Id = person.Id,
            Name = person.Name,
            DateofBirth = person.DateofBirth,
            Phone = person.Phone,
            Email = person.Email,
            RoleId = person.RoleId,
            Username = account.Username,
        });
    }

    /// <summary>
    /// Edit person by Id
    /// </summary>
    [HttpPut]
    [Route("{id:int}")]
    public IActionResult EditPerson(int id, EditPersonDTO obj)
    {
        var person = _dbContext.Persons.Find(id);

        if (person == null)
        {
            return NotFound("Can not find person to edit");
        }

        person.Name = obj.Name;
        person.DateofBirth = obj.DateofBirth;
        person.Email = obj.Email;
        person.Phone = obj.Phone;
        person.RoleId = obj.RoleId;

        try{
            _dbContext.Persons.Update(person);
            _dbContext.SaveChanges();
        }catch{
            return NotFound("Can not Edit person");
        }

        return Ok(new PersonResponseDTO{
            Id = person.Id,
            Name = person.Name,
            DateofBirth = person.DateofBirth,
            RoleId = person.RoleId,
            Phone = person.Phone,
            Email = person.Email,
        });
    }

    /// <summary>
    /// Delete person by Id
    /// </summary>
    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeletePerson(int id)
    {
        var person = _dbContext.Persons.Find(id);

        if (person == null)
        {
            return NotFound("Can not find person to delete");
        }
        try
        {
            _dbContext.Persons.Remove(person);
            _dbContext.SaveChanges();
        }
        catch (System.Exception)
        {
            return NotFound("Can not delete person");           
        }

        return Ok(new PersonResponseDTO{
            Id = person.Id,
            Name = person.Name,
            DateofBirth = person.DateofBirth,
            RoleId = person.RoleId,
            Phone = person.Phone,
            Email = person.Email,
        });
    }
}