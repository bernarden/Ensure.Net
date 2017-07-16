using System;
using System.Reflection;
#if !NET20
using System.Linq.Expressions;
#endif

namespace Ensure.Net
{
    public static class Ensure
    {
#if !NET20
        /// <summary>
        /// Determine whether the object is null, if so throws an appropriate exception depending on the input
        /// </summary>
        /// <param name="valueExpression">The object to be checked.</param>
        public static IEnsurable<T> NotNull<T>(Expression<Func<T>> valueExpression) where T : class
        {
            if (valueExpression == null)
                throw new ArgumentException("Expression cannot be null.");

            var memberExpression = valueExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression must be of type MemberExpression.");
            }

            string variableName = memberExpression.Member.Name;
            if (variableName == null)
            {
                throw new ArgumentException("Variable name cannot be null.");
            }

            var value = (T)Expression.Lambda(memberExpression).Compile().DynamicInvoke();
            if (value == null)
            {
                string message = $"'{variableName}' cannot be null.";
                throw new ArgumentNullException("", message);
            }
            return new Ensurable<T> { Value = value };
        }
#endif
        /// <summary>
        /// Determine whether an object is null, if so throws a ArgumentNullException
        /// </summary>
        /// <param name="value">The object to be checked.</param>
        public static void NotNull(object value, string parameterName)
        {
            if (string.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentException("Variable name cannot be null.");
            }

            if (value == null)
            {
                throw new ArgumentNullException("", "Variable cannot be null.");
            }
        }
        /// <summary>
        /// Determine whether a string is null, if so throws an ArgumentNullException
        /// Determine whether a string is empty, if so throws an ArgumentException
        /// </summary>
        /// <param name="value">The string variable to be checked.</param>
        public static void NotNullOrEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(parameterName))
            {
                throw new ArgumentException("Variable name cannot be null.");
            }

            if (value == null)
            {
                throw new ArgumentNullException("", "Variable cannot be null.");
            }

            if (value == "")
            {
                throw new ArgumentException("Variable cannot be an empty string.");
            }
        }
    }
}