using Application.DTO.Common;
using Application.Validation;

namespace Application.Responses.Common;

public class CommonResponse<TContent> : IResponse<TContent> 
    where TContent : IDto
{
    public CommonResponse(){}
    public CommonResponse(TContent? content, ValidationResult validationResult)
    {
        Content = content;
        ValidationResult = validationResult;
    }
    public TContent? Content { get; set; }
    public ValidationResult ValidationResult { get; set; }
}