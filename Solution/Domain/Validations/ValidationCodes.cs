namespace Domain.Validations;

public static class ValidationCodes
{
    public enum Code : byte
    {
        Ok,
        Created,
        NoContent,
        Unauthorized,
        NotFound,
        Conflict,
        UnprocessableEntity,
        
        /// <summary> Code for: FluentValidation.NotEmpty() </summary>
        Required,
        
        /// <summary>
        /// Code for: FluentValidation.EmailAddress()
        /// </summary>
        InvalidEmailAddress,
        
        /// <summary>
        /// Code for: FluentValidation.MaximumLength(number)
        /// </summary>
        GreaterThanMaximumLength,
        
        /// <summary>
        /// Code for: FluentValidation.MaximumLength(number)
        /// </summary>
        GreaterThanExpected,
        
        LesserThanExpected,
        
        /// <summary>
        /// Code for: FluentValidation.Length(number, number)
        /// </summary>
        InvalidLengthRange,
        
        /// <summary>
        /// Code for: FluentValidation.Length()
        /// </summary>
        InvalidLength,
        
        /// <summary>
        /// Code for: FluentValidation.Must(predicate)
        /// </summary>
        DateCannotBeInFuture,
        
        /// <summary>
        /// Code for: FluentValidation.Must(predicate)
        /// </summary>
        DateCannotBeGreaterThanHundredYears,
        
        /// <summary>
        /// Code for: FluentValidation.Matches(regexExpression)
        /// </summary>
        DoNotMatch,
        
        /// <summary>
        /// Code for: FluentValidation.When()
        /// </summary>
        WhenNotMatch,
        
        ObjectTooLarge
    }

    public static Dictionary<string, Code> CodesDictionary => new()
    {
        { nameof(Code.Ok), Code.Ok },
        { nameof(Code.Created), Code.Created },
        { nameof(Code.NoContent), Code.NoContent },
        { nameof(Code.Unauthorized), Code.Unauthorized },
        { nameof(Code.NotFound), Code.NotFound },
        { nameof(Code.Conflict), Code.Conflict },
        { nameof(Code.UnprocessableEntity), Code.UnprocessableEntity },
        { nameof(Code.Required), Code.Required },
        { nameof(Code.InvalidEmailAddress), Code.InvalidEmailAddress },
        { nameof(Code.GreaterThanMaximumLength), Code.GreaterThanMaximumLength },
        { nameof(Code.GreaterThanExpected), Code.GreaterThanExpected },
        { nameof(Code.LesserThanExpected), Code.LesserThanExpected },
        { nameof(Code.InvalidLengthRange), Code.InvalidLengthRange },
        { nameof(Code.InvalidLength), Code.InvalidLength },
        { nameof(Code.DateCannotBeInFuture), Code.DateCannotBeInFuture },
        { nameof(Code.DateCannotBeGreaterThanHundredYears), Code.DateCannotBeGreaterThanHundredYears },
        { nameof(Code.DoNotMatch), Code.DoNotMatch },
        { nameof(Code.WhenNotMatch), Code.WhenNotMatch },
        { nameof(Code.ObjectTooLarge), Code.ObjectTooLarge }
    };

}