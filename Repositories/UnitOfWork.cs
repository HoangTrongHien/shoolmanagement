using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public IStudentRepository Students { get; }
    public ITeacherRepository Teachers { get; }

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        Students = new StudentRepository(_dbContext);
        Teachers = new TeacherRepository(_dbContext);
    }

    public async Task<int> CompleteAsync() => await _dbContext.SaveChangesAsync();

    public void Dispose() => _dbContext.Dispose();
}