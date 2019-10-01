using System;
using Vima.Ensure.Net.Attributes;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Determine whether the string is null, if so throws an ArgumentNullException.
        /// Determine whether the string contains only white space characters, if so throws an ArgumentException.
        /// </summary>
        /// <param name="value">The string variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<string> NotNullOrWhiteSpace([ValidatedNotNull] string value,
            string parameterName = null)
        {
            CheckForNulls(value, parameterName);

            foreach (char character in value)
            {
                if (!char.IsWhiteSpace(character))
                    return new Ensurable<string>(value);
            }

            throw new ArgumentException(
                $"{parameterName ?? DefaultParameterName} cannot contain only white space characters.");
        }
    }
}