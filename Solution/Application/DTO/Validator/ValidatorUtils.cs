namespace Application.DTO.Validator;

public static class ValidatorUtils
{
    public static string RuleMessage_DataGreaterOrEqual() =>
        $"The expiration date cannot be earlier than the current date.";

    public static string RuleMessage_OnlyDecimalValue() =>
        $"The value must be a valid decimal number.";

    public static string RuleMessage_InvalidEmail() =>
        $"A valid email address is required.";

    public static string RuleMessage_CannotBeNullOrEmpty(string objName) =>
        $"Required field.\nThe field {objName} cannot be empty.";

    public static string RuleMessage_CannotZeroOrNegativeNumber() =>
        $"The number must not be zero or negative.";

    public static string RuleMessage_CannotNumsOrSymbols() =>
        $"Must not contain numbers or symbols.";

    public static string RuleMessage_ExactCharacters(byte value) =>
        $"Must contain {value} characters.";

    public static string RuleMessage_OnlyNumbers() =>
        $"The field must contain only numbers.";

    public static string RuleMessage_OnlyLetters() =>
        $"The field must contain only letters.";

    public static string RuleMessage_OnlyLettersAndNumbers() =>
        $"The field must contain only letters and numbers.";

    public static string RuleMessage_OnlyNumbersDashesAndDots() =>
        $"The field must contain only numbers, dashes, and dots.";

    public static string RuleMessage_OnlyUpperCaseLettersMaxRange(string objName, byte objMaxRange) =>
        $"The field {objName} must contain only uppercase letters.\nIt must contain {objMaxRange} characters.";

    public static string RuleMessage_OnlyLettersMaxRange(string objName, byte objMaxRange) =>
        $"The field {objName} must contain only letters.\nIt must contain {objMaxRange} characters.";

    public static string RuleMessage_OnlyNumbersLettersAndWhitespaces() =>
        $"Must not contain symbols; only letters, numbers, and spaces are allowed.";

    public static string RuleMessage_MaxCharacters(byte max) =>
        $"Must contain up to {max} characters.";

    public static string RuleMessage_MinMaxCharacters(byte min, byte max) =>
        $"Must contain between {min} and {max} characters.";

    public static string RuleMessage_InvalidPassword() =>
        $"Invalid password! The password must contain at least 6 characters!";

    public static string RuleMessage_MinMaxOnlyNumbers(byte min, byte max) =>
        $"Must contain only numbers and be between {min} and {max} digits.";

    public static string RuleMessage_MinMaxNumbers(byte min, byte max) =>
        $"Must contain between {min} and {max} numbers.";
    
    public static bool IsGuid(string guid)
        => Guid.TryParse(guid, out _);

    public static bool IsGuid(Guid guid)
        => Guid.TryParse(guid.ToString(), out _);
}
