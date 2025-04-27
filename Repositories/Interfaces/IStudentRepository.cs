using SchoolManagement.Models.Entities;

namespace SchoolManagement.Repositories.Interfaces;

public interface IStudentRepository : IGenericRepository<Student> 
{
    Task<Student> GetByIdWithAccountAsync(int id);
    Task<IEnumerable<Student>> GetAllWithAccountAsync();
    
}