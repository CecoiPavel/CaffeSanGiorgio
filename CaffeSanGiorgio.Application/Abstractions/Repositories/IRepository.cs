using CaffeSanGiorgio.Domain.Base;

namespace CaffeSanGiorgio.Application.Abstractions.Repositories;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    public Task<IEnumerable<TEntity>> GetAll();
    IQueryable<TEntity> GetReadOnlyQuery();

    IQueryable<TEntity> GetChangeTrackingQuery();
    public Task<TEntity?> GetById(int entityId);
    public Task<TEntity> Create(TEntity entity);
    public Task<TEntity> Update(TEntity entity);
    public Task Delete(int entityId);
}