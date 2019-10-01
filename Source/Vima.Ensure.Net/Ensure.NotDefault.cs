using System;
using System.Collections.Generic;
using Vima.Ensure.Net.Attributes;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Determine whether the object has a default value, if so throws an ArgumentException.
        /// </summary>
        /// <param name="value">The object variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<T> NotDefault<T>([ValidatedNotNull] T value, string parameterName = null)
        {
            if (EqualityComparer<T>.Default.Equals(value, default(T)))
            {
                throw new ArgumentException($"{parameterName ?? DefaultParameterName} cannot be set to default value.");
            }

            return new Ensurable<T>(value);
        }

        /// <summary>
        /// Determine whether the nullable struct has a null value, if so throws an ArgumentNullException.
        /// </summary>
        /// <param name="value">The nullable struct variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<T> NotDefault<T>([ValidatedNotNull] T? value, string parameterName = null)
            where T : struct
        {
            CheckForNulls(value, parameterName);

            return new Ensurable<T>(value.Value);
        }
    }
}