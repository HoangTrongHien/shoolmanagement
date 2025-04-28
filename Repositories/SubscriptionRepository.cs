using SchoolManagement.Data;
using SchoolManagement.Models.Entities;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories;

public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}