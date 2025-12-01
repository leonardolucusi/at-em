using System.Linq.Expressions;

namespace Infrastructure.Repository.Interface;

public interface IRepository<T> where T : class
{
    public Task<T> Add(T entity, CancellationToken cancellationToken = default);
    public Task AddRange(ICollection<T> entities, CancellationToken cancellationToken = default);
    public Task AddRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    public Task<T> Update(T entity, CancellationToken cancellationToken = default);
    public Task<T?> GetById(int id, bool @readonly = true, CancellationToken cancellationToken = default);
    public Task<IQueryable<T>> GetAll(bool @readonly = true, CancellationToken cancellationToken = default);
    public Task<IQueryable<T>> Search(
        Expression<Func<T, bool>> predicate,
        bool @readonly = false,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties
    );
    public Task Save(CancellationToken cancellationToken = default);
    public Task<T> Delete(T entity, CancellationToken cancellationToken = default);
    public Task DeleteRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}