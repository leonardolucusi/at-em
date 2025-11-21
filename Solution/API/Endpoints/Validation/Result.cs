using Application.Responses.Common;
using Domain.Validations;

namespace API.Endpoints.Validation;

internal static class Result
{
    internal static IResult From<T, U>(T responseObject, U? contentObject, string uri = "") 
        where T : class
        where U : class
    {
        if (!typeof(IBaseResponse<>).IsGenericTypeDefinition ||
            !typeof(T).GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IBaseResponse<>))) 
            throw new InvalidOperationException(
                $"Operation partially completed, but response object must implement {typeof(IBaseResponse<>).Name} in order to be processed. Now, there is no response.");
        
        return ValidationCodeToStatusCode((IBaseResponse<U>)responseObject, uri);
    }

    private static IResult ValidationCodeToStatusCode<U>(IBaseResponse<U> response, string uri = "")
        where U : class
    {
        if (response.ValidationResult.Codes.Any(x => x == ValidationCodes.Code.Ok))
            return Results.Ok(new { response.Content, response.ValidationResult.Messages });
        
        if (response.ValidationResult.Codes.Any(x => x == ValidationCodes.Code.Created))
            return Results.Created(uri, new { response.Content, response.ValidationResult.Messages });
        
        if (response.ValidationResult.Codes.Any(x => x == ValidationCodes.Code.NoContent))
            return Results.NoContent();
        
        if (response.ValidationResult.Codes.Any(x => x == ValidationCodes.Code.Unauthorized))
            return Results.Unauthorized();
        
        if (response.ValidationResult.Codes.Any(x => x == ValidationCodes.Code.NotFound))
            return Results.NotFound(response.ValidationResult.Messages);
        
        if (response.ValidationResult.Codes.Any(x => x == ValidationCodes.Code.Conflict))
            return Results.Conflict(response.ValidationResult.Messages);
                
        if (response.ValidationResult.Codes.Any(x => x == ValidationCodes.Code.UnprocessableEntity))
            return Results.UnprocessableEntity(response.ValidationResult.Messages);
        
        return response.ValidationResult.Codes.Any(x => 
            x == ValidationCodes.Code.Required || 
            x == ValidationCodes.Code.InvalidEmailAddress ||
            x == ValidationCodes.Code.GreaterThanMaximumLength ||
            x == ValidationCodes.Code.GreaterThanExpected ||
            x == ValidationCodes.Code.LesserThanExpected ||
            x == ValidationCodes.Code.InvalidLengthRange ||
            x == ValidationCodes.Code.InvalidLength ||
            x == ValidationCodes.Code.DateCannotBeInFuture ||
            x == ValidationCodes.Code.DateCannotBeGreaterThanHundredYears ||
            x == ValidationCodes.Code.DoNotMatch ||
            x == ValidationCodes.Code.WhenNotMatch ||
            x == ValidationCodes.Code.ObjectTooLarge)
            ? 
            Results.UnprocessableEntity(response.ValidationResult.Messages) 
            :  
            Results.BadRequest(response.ValidationResult.Messages);
    }
}