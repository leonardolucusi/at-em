using Application.DTO.Measure.Common;
using Application.DTO.Measure.Create;
using Application.Responses.Common;

namespace Application.Command.Interface;

public interface IMeasureCommandHandler
{
    public Task<CommonResponse<MeasureDto>> Create(MeasureCreateDto dto, CancellationToken cancellationToken = default);
}