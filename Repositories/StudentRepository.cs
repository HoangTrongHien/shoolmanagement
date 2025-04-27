using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}