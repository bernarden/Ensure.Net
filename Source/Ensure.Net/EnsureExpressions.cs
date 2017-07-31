#if Expressions_Supported
using System;
using System.Linq.Expressions;

namespace Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Determine whether the object is null, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the object to be checked.</param>
        public static IEnsurable<T> NotNull<T>(Expression<Func<T>> valueExpression) where T : class
        {
            IEnsurable<T> Func(T value, string parameterName) => NotNull(value, parameterName);
            return ExecuteFunctionUsingExpression(valueExpression, Func);
        }

        /// <summary>
        /// Determine whether the string is null or empty, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the string to be checked.</param>
        public static IEnsurable<string> NotNullOrEmpty(Expression<Func<string>> valueExpression)
        {
            IEnsurable<string> Func(string value, string parameterName) => NotNullOrEmpty(value, parameterName);
            return ExecuteFunctionUsingExpression(valueExpression, Func);
        }

        /// <summary>
        /// Determine whether the object has a default value, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the object to be checked.</param>
        public static IEnsurable<T> NotDefault<T>(Expression<Func<T>> valueExpression)
        {
            IEnsurable<T> Func(T value, string parameterName) => NotDefault(value, parameterName);
            return ExecuteFunctionUsingExpression(valueExpression, Func);
        }

        private static IEnsurable<T> ExecuteFunctionUsingExpression<T>(Expression<Func<T>> valueExpression,
            Func<T, string, IEnsurable<T>> action)
        {
            if (valueExpression == null)
            {
                throw new ArgumentException("Expression cannot be null.");
            }

            ConstantExpression constantExpression = valueExpression.Body as ConstantExpression;
            if (constantExpression != null)
            {
                return action.Invoke((T)constantExpression.Value, "Variable");
            }

            MemberExpression memberExpression = valueExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression must be of type MemberExpression.");
            }

            T value = (T)Expression.Lambda(memberExpression).Compile().DynamicInvoke();
            string variableName = string.IsNullOrEmpty(memberExpression.Member.Name) ? "Variable" : memberExpression.Member.Name;

            return action.Invoke(value, variableName);
        }
    }
}
#endif