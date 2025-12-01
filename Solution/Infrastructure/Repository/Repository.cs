using System.Linq.Expressions;
using Infrastructure.DataAccess;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class Repository<TEntity>(Context context) : IRepository<TEntity>, IDisposable
    where TEntity : class
{
    private bool _disposed = false;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task<TEntity> Add(
        TEntity entity,
        CancellationToken cancellationToken) =>
        (await _dbSet.AddAsync(entity, cancellationToken)).Entity;

    public async Task AddRange(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken) =>
        await _dbSet.AddRangeAsync(entities, cancellationToken);

    public async Task AddRange(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken) =>
        await _dbSet.AddRangeAsync(entities, cancellationToken);

    public async Task<TEntity> Update(
        TEntity entity,
        CancellationToken cancellationToken) =>
        await Task.Run(() => _dbSet.Update(entity).Entity, cancellationToken);

    public async Task<TEntity?> GetById(
        int id,
        bool @readonly = true,
        CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync([id], cancellationToken: cancellationToken);

        if (!@readonly && entity is not null)
            context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public async Task<IQueryable<TEntity>> GetAll(bool @readonly = true, CancellationToken cancellationToken = default) =>
        await Task.Run(() => @readonly ? _dbSet.AsNoTracking() : _dbSet, cancellationToken);

    public async Task<IQueryable<TEntity>> Search(
        Expression<Func<TEntity, bool>> predicate,
        bool @readonly = true,
        CancellationToken cancellationToken = default,
        params Expression<Func<TEntity, object>>[] includeProperties) =>
        await Task.Run(() =>
        {
            var queryableResultWithIncludes = includeProperties
                .Aggregate(_dbSet.AsQueryable(), (current, include) => current.Include(include));
            return @readonly
                ? queryableResultWithIncludes.Where(predicate).AsNoTracking()
                : queryableResultWithIncludes.Where(predicate);
        }, cancellationToken);

    public async Task Save(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);

    public async Task<TEntity> Delete(TEntity entity, CancellationToken cancellationToken = default) =>
        await Task.Run(() => _dbSet.Remove(entity).Entity, cancellationToken);
    
    public async Task DeleteRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) =>
        await Task.Run(() => _dbSet.RemoveRange(entities), cancellationToken);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing) context.Dispose();
        _disposed = true;
    }

    ~Repository() => Dispose(false);
}