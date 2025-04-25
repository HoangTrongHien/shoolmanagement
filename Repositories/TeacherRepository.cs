using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}