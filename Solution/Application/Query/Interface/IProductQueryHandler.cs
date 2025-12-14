using Application.DTO.Product.Read;
using Application.Responses.Common;

namespace Application.Query.Interface;

public interface IProductQueryHandler
{
    public Task<CommonListResponse<IEnumerable<ProductWithMeasuresDto>>> GetProductsWithMeasuresPaginated(
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default);
    public Task<CommonResponse<ProductWithMeasuresDto>> GetById(int id,
        CancellationToken cancellationToken = default);
}