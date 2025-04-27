using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<IEnumerable<Teacher>> GetAllWithAccountAsync()
    {
        return await GetAllAsync(p => p.Account);
    }

    public async Task<Teacher> GetByIdWithAccountAsync(int id)
    {
        return await GetByIdAsync(id, p => p.Account);
    }
}