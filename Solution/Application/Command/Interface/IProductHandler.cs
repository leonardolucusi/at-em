using Application.DTO.Product.Create;
using Application.ResponseUtility;

namespace Application.Command.Interface;

public interface IProductHandler
{
    public Task<Response> HandleAdd(ProductCreateDto productCreateDto, CancellationToken cancellationToken = default);
}