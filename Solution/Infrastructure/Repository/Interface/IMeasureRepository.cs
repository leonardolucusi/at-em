using Domain.Product;
using Infrastructure.Utility;

namespace Infrastructure.Repository.Interface;

public interface IMeasureRepository
{
    public Task<IEnumerable<Measure>> GetMeasuresByProductId(int id,
        CancellationToken cancellationToken = default);
    public Task<DeleteResult> DeleteMeasuresByProductId(int id, CancellationToken cancellationToken = default);
}