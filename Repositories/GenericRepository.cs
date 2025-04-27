using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Repositories.Interfaces;

namespace SchoolManagement.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach(var include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.ToListAsync();
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var objs = await _dbSet.ToListAsync();

        return objs;
    }
    public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var obj = await query.FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id)
            ?? throw new KeyNotFoundException($"Entity with Id {id} not found");

        return obj;
    }
    public async Task<T> GetByIdAsync(int id)
    {     
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

}