using System;
using System.Collections;
using Vima.Ensure.Net.Attributes;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Determine whether the <see cref="string"/> value is null or empty.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException">Thrown when specified value is null.</exception>
        /// <exception cref="ArgumentException">Thrown when specified value is empty.</exception>
        public static IEnsurable<string> NotNullOrEmpty(
            [ValidatedNotNull] string value,
            string parameterName = null)
        {
            CheckForNulls(value, parameterName);

            if (value.Equals(string.Empty))
            {
                throw new ArgumentException($"{parameterName ?? DefaultParameterName} cannot be an empty string.");
            }

            return new Ensurable<string>(value);
        }

        /// <summary>
        /// Determine whether the <typeparamref name="T"/> value is null or empty.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <typeparam name="T">A type that inherits from the <see cref="IEnumerable"/> interface.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when specified value is null.</exception>
        /// <exception cref="ArgumentException">Thrown when specified value is empty.</exception>
        public static IEnsurable<T> NotNullOrEmpty<T>(
            [ValidatedNotNull] T value,
            string parameterName = null) where T : IEnumerable
        {
            CheckForNulls(value, parameterName);
        
            if (Extensions.IsEmpty(value))
            {
                throw new ArgumentException($"{parameterName ?? DefaultParameterName} cannot be empty.");
            }
        
            return new Ensurable<T>(value);
        }
    }
}