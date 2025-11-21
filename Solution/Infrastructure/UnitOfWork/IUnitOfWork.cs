namespace Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    public Task BeginTransaction(CancellationToken cancellationToken = default);
    public Task Rollback(CancellationToken cancellationToken = default);
    public Task CommitTransaction(CancellationToken cancellationToken = default);
}