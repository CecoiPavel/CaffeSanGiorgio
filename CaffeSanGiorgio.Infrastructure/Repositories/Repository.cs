using CaffeSanGiorgio.Application.Abstractions.Repositories;
using CaffeSanGiorgio.Domain.Base;
using CaffeSanGiorgio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CaffeSanGiorgio.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private DbSet<TEntity> Table { get; }
    private readonly SanGiorgioContext _context;

    protected Repository(SanGiorgioContext context)
    {
        _context = context;
        ArgumentNullException.ThrowIfNull(context);

        Table = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public IQueryable<TEntity> GetReadOnlyQuery()
    {
        return Table.AsNoTracking();
    }

    public IQueryable<TEntity> GetChangeTrackingQuery()
    {
        return Table.AsTracking();
    }

    public async Task<TEntity?> GetById(int entityId)
    {
        return await _context.Set<TEntity>().FindAsync(entityId);
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    public async Task Delete(int entityId)
    {
        var entity = await _context.Set<TEntity>().FindAsync(entityId);
        if (entity != null)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}