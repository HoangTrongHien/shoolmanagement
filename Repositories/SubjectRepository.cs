using SchoolManagement.Data;
using SchoolManagement.Models.Entities;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories;

public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}