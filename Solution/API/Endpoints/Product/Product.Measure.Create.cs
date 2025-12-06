using API.Endpoints.Validation;
using Application.Command.Interface;
using Application.DTO.Measure.Create;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> CreateMeasure(
        MeasureCreateDto dto,
        IMeasureCommandHandler measureCommandHandler,
        CancellationToken cancellationToken)
    {
       var response = await measureCommandHandler.Create(dto, cancellationToken);
       return Result.From(response, response.Content);
    }
}