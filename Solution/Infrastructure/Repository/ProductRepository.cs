using Domain.Product;
using Infrastructure.DataAccess;
using Infrastructure.Repository.Interface;

namespace Infrastructure.Repository;

public class ProductRepository(Context context) : Repository<Product>(context) ,IProductRepository
{
}