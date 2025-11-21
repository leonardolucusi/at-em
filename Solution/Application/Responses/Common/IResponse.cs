using Application.DTO.Common;

namespace Application.Responses.Common;

public interface IResponse<TContent> : IBaseResponse<TContent>
    where TContent : IDto
{
    
}