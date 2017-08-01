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
            CheckForNulls(value, ref parameterName);

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
            CheckForNulls(value, ref parameterName);

            if (value.Equals(string.Empty))
            {
                throw new ArgumentException($"{parameterName} cannot be an empty string.");
            }

            return new Ensurable<string>(value);
        }

        /// <summary>
        /// Determine whether a IEnumerable is null, if so throws an ArgumentNullException.
        /// Determine whether a IEnumerable is empty, if so throws an ArgumentException.
        /// </summary>
        /// <param name="value">The IEnumerable variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<IEnumerable<T>> NotNullOrEmpty<T>(IEnumerable<T> value, string parameterName)
        {
            CheckForNulls(value, ref parameterName);

            if (Helpers.GetCount(value) == 0L)
            {
                throw new ArgumentException($"{parameterName} cannot be an empty.");
            }

            return new Ensurable<IEnumerable<T>>(value);
        }

        /// <summary>
        /// Determine whether an object has a default value, if so throws an ArgumentException.
        /// </summary>
        /// <param name="value">The object variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<T> NotDefault<T>(T value, string parameterName)
        {
            SetDefaultParameterNameIfNull(ref parameterName);

            if (EqualityComparer<T>.Default.Equals(value, default(T)))
            {
                throw new ArgumentException($"{parameterName} cannot be set to default value.");
            }

            return new Ensurable<T>(value);
        }

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