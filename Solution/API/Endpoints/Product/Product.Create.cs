using API.Endpoints.Validation;
using Application.Command.Interface;
using Application.DTO.Product.Create;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> CreateProduct(
        IProductCommandHandler productCommandHandler,
        ProductCreateDto productCreateDto,
        CancellationToken cancellationToken)
    {
        var response = await productCommandHandler.Create(productCreateDto, cancellationToken);
        return Result.From(response, response.Content);
    }
}