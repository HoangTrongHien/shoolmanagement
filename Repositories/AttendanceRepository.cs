using SchoolManagement.Data;
using SchoolManagement.Models.Entities;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories;

public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
{
    public AttendanceRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}