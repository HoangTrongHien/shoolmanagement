using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models.DTOs.Person;
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
    public async Task<IActionResult> GetAllPersons()
    {
        var persons = await _dbContext.Persons.Include(p => p.Account).ToListAsync();

        var personDtos = persons.Select(person => new PersonResponseDTO{
            Id = person.Id,
            Name = person.Name,
            DateofBirth = person.DateofBirth,
            Phone = person.Phone,
            Email = person.Email,
            Role = person.Role,
            Username = person.Account?.Username
        }).ToList();
        
        return Ok(personDtos);
    }

    /// <summary>
    /// Get person by the ID
    /// </summary>
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetPersonById(int id)
    {
        var person = await _dbContext.Persons.Include(p => p.Account).FirstOrDefaultAsync(p => p.Id == id);

        if (person == null)
        {
            return NotFound($"person with ID {id} is not found");
        }

        return Ok(new PersonResponseDTO{
            Id = person.Id,
            Name = person.Name,
            DateofBirth = person.DateofBirth,
            Phone = person.Phone,
            Role = person.Role,
            Email = person.Email,
            Username = person.Account?.Username
        });
    }

    /// <summary>
    /// Create person without init account
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreatePerson(CreatePersonDTO obj)
    {
        Person person = new Person(){
            Name = obj.Name,
            DateofBirth = obj.DateofBirth,
            Phone = obj.Phone,
            Email = obj.Email,
            Role = obj.Role,
        };

        try
        {
            _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();
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
            Role = person.Role,
            Username = person.Account?.Username,
        });
    }

    /// <summary>
    /// Create person within init account
    /// </summary>
    [HttpPost("CreatePersonWithAccount")]
    public async Task<IActionResult> CreatePersonWithAccount(CreatePersonWithAccountDTO obj)
    {
        Person person = new Person()
        {
            Name = obj.Name,
            DateofBirth = obj.DateofBirth,
            Phone = obj.Phone,
            Email = obj.Email,
            Role = obj.Role,    
        };

        Account account = new Account()
        {
            Id = person.Id,
            Username = obj.Username,
            Password = obj.Password,
            Person = person,
        };

        person.Account = account;
        try
        {
            _dbContext.Persons.Add(person);
            _dbContext.Accounts.Add(account);
            await _dbContext.SaveChangesAsync();
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
            Role = person.Role,
            Username = person.Account?.Username,
        });
    }

    /// <summary>
    /// Edit person by Id
    /// </summary>
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> EditPerson(int id, EditPersonDTO obj)
    {
        var person = await _dbContext.Persons.Include(p => p.Account).FirstOrDefaultAsync(p => p.Id == id);

        if (person == null)
        {
            return NotFound("Can not find person to edit");
        }

        person.Name = obj.Name;
        person.DateofBirth = obj.DateofBirth;
        person.Email = obj.Email;
        person.Phone = obj.Phone;

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
            Role = person.Role,
            Phone = person.Phone,
            Email = person.Email,
            Username = person.Account?.Username
        });
    }

    /// <summary>
    /// Delete person by Id
    /// </summary>
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var person = await _dbContext.Persons.Include(p => p.Account).FirstOrDefaultAsync(p => p.Id == id);

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
            Role = person.Role,
            Phone = person.Phone,
            Email = person.Email,
            Username = person.Account?.Username
        });
    }
}