using System;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        private const string DefaultParameterName = "Variable";

        private static void CheckForNulls<T>(T value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException("", $"{parameterName ?? DefaultParameterName} cannot be null.");
            }
        }
    }
}