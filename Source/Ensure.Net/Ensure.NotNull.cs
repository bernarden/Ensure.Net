using System;
using Ensure.Net.Helpers;
#if Expressions_Supported
using System.Linq.Expressions;
#endif

namespace Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Determine whether the object is null, if so throws an ArgumentNullException.
        /// </summary>
        /// <param name="value">The object to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<T> NotNull<T>(T value, string parameterName) where T : class
        {
            CheckForNulls(value, ref parameterName);

            return new Ensurable<T>(value);
        }

#if Expressions_Supported
        /// <summary>
        /// Determine whether the object is null, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the object to be checked.</param>
        public static IEnsurable<T> NotNull<T>(Expression<Func<T>> valueExpression) where T : class
        {
            IEnsurable<T> Func(T value, string parameterName) => NotNull(value, parameterName);
            return ExpressionFunctionExecutor.ExecuteFunctionWithExpression(valueExpression, Func);
        }
#endif
    }
}