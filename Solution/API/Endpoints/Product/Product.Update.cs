using API.Endpoints.Validation;
using Application.Command.Interface;
using Application.DTO.Product.Update;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> UpdateProduct(
        IProductCommandHandler productCommandHandler,
        ProductUpdateDto productUpdateDto,
        CancellationToken cancellationToken)
    {
        var response = await productCommandHandler.Update(productUpdateDto, cancellationToken);
        return Result.From(response, response.Content);
    }
}