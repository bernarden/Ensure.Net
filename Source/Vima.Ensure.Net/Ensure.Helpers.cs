using System;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        private const string DefaultParameterName = "Variable";

        private static string GenerateNullErrorMessage(string? parameterName) =>
            $"{parameterName ?? DefaultParameterName} cannot be null.";

        private static T ThrowExceptionIfNull<T>(T? value, string? parameterName) where T: class
        {
            return value ?? throw new ArgumentNullException("", GenerateNullErrorMessage(parameterName));
        }

        private static T ThrowExceptionIfNull<T>(T? value, string? parameterName) where T : struct
        {
            return value ?? throw new ArgumentNullException("", GenerateNullErrorMessage(parameterName));
        }

        private static string ThrowExceptionIfStringIsNullOrEmpty(string? value, string? parameterName)
        {
            string nonNullValue = ThrowExceptionIfNull(value, parameterName);

            if (nonNullValue.Equals(string.Empty))
            {
                throw new ArgumentException($"{parameterName ?? DefaultParameterName} cannot be an empty string.");
            }

            return nonNullValue;
        }
    }
}