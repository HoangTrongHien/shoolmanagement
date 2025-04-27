using SchoolManagement.Models.Entities;

namespace SchoolManagement.Repositories.Interfaces;

public interface ITeacherRepository : IGenericRepository<Teacher>
{
    Task<Teacher> GetByIdWithAccountAsync(int id);
    Task<IEnumerable<Teacher>> GetAllWithAccountAsync();
}