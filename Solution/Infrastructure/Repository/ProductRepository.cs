using Domain.Product;
using Infrastructure.DataAccess;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProductRepository(Context context) : Repository<Product>(context), IProductRepository
{
    private readonly Context _context = context;

    public async Task<IEnumerable<Product>> GetProductsWithMeasures(
        int pageSize,
        int pageNumber,
        CancellationToken cancellationToken = default) =>
        await _context.Products
            .Include(x => x.Measures)
            .Skip(pageNumber)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
}

