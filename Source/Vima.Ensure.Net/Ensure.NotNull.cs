using System;
using Vima.Ensure.Net.Attributes;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Checks whether <typeparamref name="T"/> value is <see langword="null"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <typeparam name="T">A reference type of a <paramref name="value"/> to check.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when specified <paramref name="value"/> is <see langword="null"/>.</exception>
        public static IEnsurable<T> NotNull<T>([ValidatedNotNull] T value, string parameterName = null) where T : class
        {
            ThrowExceptionIfNull(value, parameterName);

            return new Ensurable<T>(value);
        }

        /// <summary>
        /// Checks whether <typeparamref name="T"/> value is <see langword="null"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <typeparam name="T">A structure type of a <paramref name="value"/> to check.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when specified <paramref name="value"/> is <see langword="null"/>.</exception>
        public static IEnsurable<T> NotNull<T>([ValidatedNotNull] T? value, string parameterName = null)
            where T : struct
        {
            ThrowExceptionIfNull(value, parameterName);

            return new Ensurable<T>(value.Value);
        }
    }
}