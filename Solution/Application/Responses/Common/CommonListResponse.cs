using Application.Validation;

namespace Application.Responses.Common;

public class CommonListResponse<TContent> : IListResponse<TContent>
{
    public TContent? Content { get; set; }
    public ValidationResult ValidationResult { get; set; }
}