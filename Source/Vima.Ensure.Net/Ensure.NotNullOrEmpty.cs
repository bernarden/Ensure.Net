using System;
using System.Collections.Generic;
using Vima.Ensure.Net.Attributes;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Determine whether the string is null, if so throws an ArgumentNullException.
        /// Determine whether the string is empty, if so throws an ArgumentException.
        /// </summary>
        /// <param name="value">The string variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<string> NotNullOrEmpty([ValidatedNotNull] string value, string parameterName = null)
        {
            CheckForNulls(value, parameterName);

            if (value.Equals(string.Empty))
            {
                throw new ArgumentException($"{parameterName ?? DefaultParameterName} cannot be an empty string.");
            }

            return new Ensurable<string>(value);
        }

        /// <summary>
        /// Determine whether the IEnumerable is null, if so throws an ArgumentNullException.
        /// Determine whether the IEnumerable is empty, if so throws an ArgumentException.
        /// </summary>
        /// <param name="value">The IEnumerable variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<IEnumerable<T>> NotNullOrEmpty<T>([ValidatedNotNull] IEnumerable<T> value,
            string parameterName = null)
        {
            CheckForNulls(value, parameterName);

            if (Extensions.GetCount(value) == 0L)
            {
                throw new ArgumentException($"{parameterName ?? DefaultParameterName} cannot be empty.");
            }

            return new Ensurable<IEnumerable<T>>(value);
        }
    }
}