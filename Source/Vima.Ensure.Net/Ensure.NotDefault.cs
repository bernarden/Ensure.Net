using System;
using System.Collections.Generic;
using Vima.Ensure.Net.Attributes;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Checks whether <typeparamref name="T"/> has a default value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <typeparam name="T">A type of a <paramref name="value"/> to check.</typeparam>
        /// <exception cref="ArgumentException">Thrown when specified <paramref name="value"/> equals to a default value.</exception>
        public static IEnsurable<T> NotDefault<T>([ValidatedNotNull] T value, string parameterName = null)
        {
            if (EqualityComparer<T>.Default.Equals(value, default))
            {
                throw new ArgumentException($"{parameterName ?? DefaultParameterName} cannot be set to the default value.");
            }

            return new Ensurable<T>(value);
        }

        /// <summary>
        /// Checks whether <typeparamref name="T"/>? has a default value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <typeparam name="T">A structure type of a <paramref name="value"/> to check.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when specified <paramref name="value"/> is <see langword="null"/>.</exception>
        public static IEnsurable<T> NotDefault<T>([ValidatedNotNull] T? value, string parameterName = null)
            where T : struct
        {
            ThrowExceptionIfNull(value, parameterName);

            return new Ensurable<T>(value.Value);
        }
    }
}