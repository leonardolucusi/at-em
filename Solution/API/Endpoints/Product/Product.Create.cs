using API.Endpoints.Validation;
using Application.Command.Interface;
using Application.DTO.Product.Create;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> CreateProduct(
        IProductHandler productHandler,
        ProductCreateDto productCreateDto,
        CancellationToken cancellationToken)
    {
        var response = await productHandler.HandleAdd(productCreateDto, cancellationToken);
        return Result.From(response, response.Content);
    }
}