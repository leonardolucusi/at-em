using Infrastructure.Utility;

namespace Infrastructure.Repository.Interface;

public interface IMeasureRepository
{
    public Task<DeleteResult> DeleteMeasuresByProductId(int id, CancellationToken cancellationToken = default);
}