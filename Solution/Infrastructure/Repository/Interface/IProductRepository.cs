using Domain.Product;

namespace Infrastructure.Repository.Interface;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetProductsWithMeasures(int pageSize, int pageNumber,
        CancellationToken cancellationToken = default);
}