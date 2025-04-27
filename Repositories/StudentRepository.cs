using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<IEnumerable<Student>> GetAllWithAccountAsync()
    {
        return await GetAllAsync(p => p.Account);
    }

    public async Task<Student> GetByIdWithAccountAsync(int id)
    {
        return await GetByIdAsync(id, p => p.Account);
    }
}