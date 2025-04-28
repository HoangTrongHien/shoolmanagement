using SchoolManagement.Data;
using SchoolManagement.Models.Entities;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories;

public class ScheduleInformationRepository : GenericRepository<ScheduleInformation>, IScheduleInformationRepository
{
    public ScheduleInformationRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}