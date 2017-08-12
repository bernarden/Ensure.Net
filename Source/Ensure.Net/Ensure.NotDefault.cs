using System;
using System.Collections.Generic;
using Vima.Ensure.Net;
#if Expressions_Supported
using System.Linq.Expressions;
#endif

namespace Vima.Ensure.Net
{
    public static partial class Ensure 
    {
        /// <summary>
        /// Determine whether the object has a default value, if so throws an ArgumentException.
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

#if Expressions_Supported
        /// <summary>
        /// Determine whether the object has a default value, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the object to be checked.</param>
        public static IEnsurable<T> NotDefault<T>(Expression<Func<T>> valueExpression)
        {
            IEnsurable<T> Func(T value, string parameterName) => NotDefault(value, parameterName);
            return ExpressionFunctionExecutor.ExecuteFunctionWithGenericValueInExpression(valueExpression, Func);
        }
#endif
    }
}