namespace SchoolManagement.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository Students { get; }
    ITeacherRepository Teachers { get; }
    Task<int> CompleteAsnc();
}