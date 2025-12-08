using API.Endpoints.Validation;
using Application.Command.Interface;
using Application.DTO.Measure.Update;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> UpdateMeasure(
        MeasureUpdateDto dto,
        IMeasureCommandHandler measureCommandHandler,
        CancellationToken cancellationToken)
    {
        var response = await measureCommandHandler.UpdateMeasureById(dto, cancellationToken);
        return Result.From(response, response.Content);
    }
}