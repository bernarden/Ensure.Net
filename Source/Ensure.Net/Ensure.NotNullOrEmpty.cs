using System;
using System.Collections.Generic;
using Ensure.Net.Helpers;
#if Expressions_Supported
using System.Linq.Expressions;
#endif

namespace Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Determine whether the string is null, if so throws an ArgumentNullException.
        /// Determine whether the string is empty, if so throws an ArgumentException.
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
        /// Determine whether the IEnumerable is null, if so throws an ArgumentNullException.
        /// Determine whether the IEnumerable is empty, if so throws an ArgumentException.
        /// </summary>
        /// <param name="value">The IEnumerable variable to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<IEnumerable<T>> NotNullOrEmpty<T>(IEnumerable<T> value, string parameterName)
        {
            CheckForNulls(value, ref parameterName);

            if (Extensions.GetCount(value) == 0L)
            {
                throw new ArgumentException($"{parameterName} cannot be an empty.");
            }

            return new Ensurable<IEnumerable<T>>(value);
        }

#if Expressions_Supported
        /// <summary>
        /// Determine whether the string is null or empty, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the string to be checked.</param>
        public static IEnsurable<string> NotNullOrEmpty(Expression<Func<string>> valueExpression)
        {
            IEnsurable<string> Func(string value, string parameterName) => NotNullOrEmpty(value, parameterName);
            return ExpressionFunctionExecutor.ExecuteFunctionWithExpression(valueExpression, Func);
        }

        /// <summary>
        /// Determine whether the IEnumerable is null or empty, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the IEnumerable to be checked.</param>
        public static IEnsurable<IEnumerable<T>> NotNullOrEmpty<T>(Expression<Func<IEnumerable<T>>> valueExpression)
        {
            IEnsurable<IEnumerable<T>> Func(IEnumerable<T> value, string parameterName) => NotNullOrEmpty(value, parameterName);
            return ExpressionFunctionExecutor.ExecuteFunctionWithExpression(valueExpression, Func);
        }
#endif
    }
}