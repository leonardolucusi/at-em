using Application.DTO.Measure.Common;
using Application.Responses.Common;

namespace Application.Query.Interface;

public interface IMeasureQueryHandler
{
    public Task<CommonListResponse<IEnumerable<MeasureDto>>> GetMeasuresByProductId(int id,
        CancellationToken cancellationToken = default);
}