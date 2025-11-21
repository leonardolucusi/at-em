using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork(Context context) : IUnitOfWork, IDisposable
{
    private bool _disposed;
    private IDbContextTransaction? _transaction = null;
    
    public async Task BeginTransaction(CancellationToken cancellationToken)
    {
        if (_transaction is not null)
        {
            throw new InvalidOperationException(
                $"Transaction with Id: {_transaction.TransactionId} has already been started!");
        }
        
        _transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        _disposed = false;
    }

    public async Task CommitTransaction(CancellationToken cancellationToken)
    {
        try
        {
            await Save(cancellationToken);
            await _transaction!.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            await Rollback(cancellationToken);
            throw;
        }
    }

    public async Task Rollback(CancellationToken cancellationToken)
    {
        await _transaction!.RollbackAsync(cancellationToken);
    }

    public async Task Save(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _transaction?.Dispose();
            context.Dispose();
        }
        
        this._disposed = true;
    }
}