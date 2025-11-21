using Application.DTO.Product.Create;
using Application.Responses.Common;

namespace Application.Command.Interface;

public interface IProductHandler
{
    public Task<CommonResponse<ProductCreatedDto>> HandleAdd(ProductCreateDto productCreateDto, CancellationToken cancellationToken = default);
}