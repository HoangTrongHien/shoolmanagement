using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Data;
using SchoolManagement.Models.DTOs;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _dbcontext;

    public AccountController(AppDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    /// <summary>
    /// Gets the list of all accounts
    /// </summary>
    [HttpGet]
    public IActionResult GetAllAccounts()
    {
        var accounts = _dbcontext.Accounts.ToList();
        
        var accountDtos = accounts.Select(account => new AccountResponseDTO{
            Id = account.Id,
            Username = account.Username,
        }).ToList();
        return Ok(accountDtos);
    }

    /// <summary>
    /// Gets account by the ID
    /// </summary>
    [HttpGet]
    [Route("id:int")]
    public IActionResult GetAccountById(int id)
    {
        var account = _dbcontext.Accounts.Find(id);

        if (account == null)
        {
            return NotFound($"Account with ID {id} is not found");
        }

        return Ok(new AccountResponseDTO{
            Id = account.Id,
            Username = account.Username,
        });
    }

    /// <summary>
    /// Create account
    /// </summary>
    [HttpPost]
    public IActionResult CreateAccount(CreateAccountDTO obj){

        var person = _dbcontext.Persons.Find(obj.AccountId);

        if (person == null)
        {
            return NotFound($"Person with ID {obj.AccountId} not found");
        }

        var existingAccount = _dbcontext.Accounts.Find(obj.AccountId);

        if (existingAccount != null)
        {
            return NotFound("This person already has an account");
        }


        Account account = new Account()
        {
            Id = obj.AccountId,
            Username = obj.Username,
            Password = obj.Password,
            Person = person
        };

        try
        {
            _dbcontext.Accounts.Add(account);
            _dbcontext.SaveChanges();
        }
        catch (System.Exception)
        {
            
            return NotFound("Can not update new information for this account");
        }
        

        return Ok(new AccountResponseDTO{
            Id = account.Id,
            Username = account.Username,
        });
    }

    /// <summary>
    /// Update account by the ID
    /// </summary>
    [HttpPut]
    [Route("{id:int}")]
    public IActionResult UpdateAccount(int id, UpdateAccountDTO obj)
    {
        var account = _dbcontext.Accounts.Find(id);

        if (account == null)
        {
            return NotFound($"Account with ID {id} not found");
        }

        account.Username = obj.Username;
        account.Password = obj.Password;

        _dbcontext.Accounts.Add(account);
        _dbcontext.SaveChanges();

        return Ok(new AccountResponseDTO{
            Id = account.Id,
            Username = account.Username,
        });
    }

    /// <summary>
    /// Delete account by the ID
    /// </summary>
    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteAccount(int id)
    {
        var account = _dbcontext.Accounts.Find(id);

        if (account == null){
            return NotFound("This account doesn't exist");
        }

        try
        {
            _dbcontext.Accounts.Remove(account);
            _dbcontext.SaveChanges();
        }
        catch (System.Exception)
        {
            return NotFound("Can not delete this account!");
        }

        return Ok(new AccountResponseDTO{
            Id = account.Id,
            Username = account.Username,
        });
    }
}

