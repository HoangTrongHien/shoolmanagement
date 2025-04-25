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
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<T> GetByIdAsync(int id)
    {
        var obj = await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
        return obj;
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);
}