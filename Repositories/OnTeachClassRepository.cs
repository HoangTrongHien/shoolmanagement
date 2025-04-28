using SchoolManagement.Data;
using SchoolManagement.Models.Entities;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories;

public class OnTeachClassRepository : GenericRepository<OnTeachClass>, IOnTeachClassRepository
{
    public OnTeachClassRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}