using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public IStudentRepository Students { get; }
    public ITeacherRepository Teachers { get; }
    public IAttendanceRepository Attendances { get; }
    public ISubjectRepository Subjects { get; }
    public IOnTeachClassRepository OnTeachClasses { get; }
    public ISubscriptionRepository Subscriptions { get; }
    public IScheduleInformationRepository ScheduleInformations { get; }


    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        Students = new StudentRepository(_dbContext);
        Teachers = new TeacherRepository(_dbContext);
        Attendances = new AttendanceRepository(_dbContext);
        Subjects = new SubjectRepository(_dbContext);
        OnTeachClasses = new OnTeachClassRepository(_dbContext);
        Subscriptions = new SubscriptionRepository(_dbContext);
        ScheduleInformations = new ScheduleInformationRepository(_dbContext);
    }

    public async Task<int> CompleteAsync() => await _dbContext.SaveChangesAsync();

    public void Dispose() => _dbContext.Dispose();
}