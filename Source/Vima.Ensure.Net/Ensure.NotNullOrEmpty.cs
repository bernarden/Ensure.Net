using System;
using System.Collections;
using Vima.Ensure.Net.Attributes;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Checks whether <see cref="string"/> value is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException">Thrown when specified <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when specified <paramref name="value"/> is empty.</exception>
        public static IEnsurable<string> NotNullOrEmpty(
            [ValidatedNotNull] string? value,
            string? parameterName = null)
        {
            string validatedValue = ThrowExceptionIfStringIsNullOrEmpty(value, parameterName);

            return new Ensurable<string>(validatedValue);
        }

        /// <summary>
        /// Checks whether <typeparamref name="T"/> value is <see langword="null"/> or empty.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <typeparam name="T">A type that inherits from the <see cref="IEnumerable"/> interface.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when specified <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when specified <paramref name="value"/> is empty.</exception>
        public static IEnsurable<T> NotNullOrEmpty<T>(
            [ValidatedNotNull] T? value,
            string? parameterName = null) where T : class, IEnumerable
        {
            T nonNullValue = ThrowExceptionIfNull(value, parameterName);

            if (Extensions.IsEmpty(nonNullValue))
            {
                throw new ArgumentException($"{parameterName ?? DefaultParameterName} cannot be empty.");
            }

            return new Ensurable<T>(nonNullValue);
        }
    }
}