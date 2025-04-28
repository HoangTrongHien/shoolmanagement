namespace SchoolManagement.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository Students { get; }
    ITeacherRepository Teachers { get; }
    ISubjectRepository Subjects { get; }
    ISubscriptionRepository Subscriptions { get; }
    IScheduleInformationRepository ScheduleInformations { get; }
    IOnTeachClassRepository OnTeachClasses { get; }
    IAttendanceRepository Attendances { get; }

    Task<int> CompleteAsync();
}