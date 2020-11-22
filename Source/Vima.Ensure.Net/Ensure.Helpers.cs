using System;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        private const string DefaultParameterName = "Variable";

        private static void ThrowExceptionIfNull<T>(T value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException("", $"{parameterName ?? DefaultParameterName} cannot be null.");
            }
        }

        private static void ThrowExceptionIfStringIsNullOrEmpty(string value, string parameterName)
        {
            ThrowExceptionIfNull(value, parameterName);

            if (value.Equals(string.Empty))
            {
                throw new ArgumentException($"{parameterName ?? DefaultParameterName} cannot be an empty string.");
            }
        }

    }
}