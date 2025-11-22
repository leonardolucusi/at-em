using Application.DTO.Product.Create;
using Application.DTO.Product.Update;
using Application.Responses.Common;

namespace Application.Command.Interface;

public interface IProductCommandHandler
{
    public Task<CommonResponse<ProductCreatedDto>> Create(ProductCreateDto productCreateDto, CancellationToken cancellationToken = default);

    public Task<CommonResponse<ProductUpdatedDto>> Update(ProductUpdateDto productUpdateDto, CancellationToken cancellationToken = default);
}