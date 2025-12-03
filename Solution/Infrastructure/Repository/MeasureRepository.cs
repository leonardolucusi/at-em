using Domain.Product;
using Infrastructure.DataAccess;
using Infrastructure.Repository.Interface;
using Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MeasureRepository(Context context) : Repository<Measure>(context), IMeasureRepository
{
    public async Task<IEnumerable<Measure>> GetMeasuresByProductId(int id,
        CancellationToken cancellationToken = default) =>
        await Search(x => x.ProductId == id, true, cancellationToken);
    
    public async Task<DeleteResult> DeleteMeasuresByProductId(int id, CancellationToken cancellationToken = default)
    {
        int rowsAffected = await context.Measures.Where(x => x.ProductId == id).ExecuteDeleteAsync(cancellationToken);
        return rowsAffected == 0 ? DeleteResult.NotFound : DeleteResult.Deleted;
    }
}