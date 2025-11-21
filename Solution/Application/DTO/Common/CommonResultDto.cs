namespace Application.DTO.Common;

public record CommonResultDto : IDto
{
    public required string Message { get; init; }
}