using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public partial record Identification
    {
        private const int DefaultLength = 10; // Longitud esperada del n�mero de tel�fono
        private const string Pattern = @"^\d+$";

        private Identification(string value) => Value = value;

        public static Identification? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !IdentificationRegex().IsMatch(value) || value.Length != DefaultLength)
            {
                return null;
            }

            return new Identification(value);
        }

        public string Value { get; init; }

        [GeneratedRegex(Pattern)]
        private static partial Regex IdentificationRegex();
    }
}