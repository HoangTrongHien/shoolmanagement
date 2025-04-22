using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Data
{
    public class AppDbContext: DbContext{
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}