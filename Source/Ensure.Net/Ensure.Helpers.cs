using System;

namespace Ensure.Net
{
    public static partial class Ensure
    {
        private static void CheckForNulls<T>(T value, ref string parameterName) where T : class
        {
            SetDefaultParameterNameIfNull(ref parameterName);

            if (value == null)
            {
                throw new ArgumentNullException("", $"{parameterName} cannot be null.");
            }
        }

        private static void SetDefaultParameterNameIfNull(ref string parameterName)
        {
            if (parameterName == null)
            {
                parameterName = "Variable";
            }
        }
    }
}