using Application.Validation;

namespace Application.Responses.Common;

public interface IBaseResponse<TContent>
{
    public TContent? Content { get; set; }
    public ValidationResult ValidationResult { get; set; }
}