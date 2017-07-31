using System;
using System.Collections.Generic;

namespace Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Determine whether an object is null, if so throws an ArgumentNullException.
        /// </summary>
        /// <param name="value">The object to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<T> NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException("", $"{parameterName} cannot be null.");
            }

            return new Ensurable<T>(value);
        }

        /// <summary>
        /// Determine whether a string is null, if so throws an ArgumentNullException.
        /// Determine whether a string is empty, if so throws an ArgumentException.
        /// </summary>
        /// <param name="value">The string variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<string> NotNullOrEmpty(string value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException("", $"{parameterName} cannot be null.");
            }

            if (value.Equals(string.Empty))
            {
                throw new ArgumentException($"{parameterName} cannot be an empty string.");
            }

            return new Ensurable<string>(value);
        }

        /// <summary>
        /// Determine whether an object has a default value, if so throws an ArgumentException.
        /// </summary>
        /// <param name="value">The object variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<T> NotDefault<T>(T value, string parameterName)
        {
            if (EqualityComparer<T>.Default.Equals(value, default(T)))
            {
                throw new ArgumentException($"{parameterName} cannot be set to default value.");
            }

            return new Ensurable<T>(value);
        }

    }
}