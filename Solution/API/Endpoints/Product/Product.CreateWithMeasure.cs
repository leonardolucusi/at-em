using API.Endpoints.Validation;
using Application.Command.Interface;
using Application.DTO.Product.CreateWithMeasure;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> CreateProductWithMeasures(
        [FromBody] ProductMeasureCreateDto productMeasureCreateDto,
        IProductCommandHandler productCommandHandler,
        CancellationToken cancellationToken)
    {
        var response = await productCommandHandler.CreateWithMeasure(productMeasureCreateDto, cancellationToken);
        return Result.From(response, response.Content);
    }
}