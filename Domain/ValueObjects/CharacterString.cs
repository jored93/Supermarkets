using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial record CharacterString
    {
        private const int DefaultLength = 10;
    private const string Pattern = @"^[a-zA-Z]+$";

    private CharacterString(string value) => Value = value;

    public static CharacterString? Create(string value)
    {
        if(string.IsNullOrEmpty(value) || !CharacterStringRegex().IsMatch(value) || value.Length != DefaultLength)
        {
            return null;
        }

        return new CharacterString(value);
    }

    public string Value { get; init; }

    [GeneratedRegex(Pattern)]
    private static partial Regex CharacterStringRegex();
    }
}