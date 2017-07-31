using System;
using System.Collections.Generic;
#if Expressions_Supported
using System.Linq.Expressions;
#endif

namespace Ensure.Net
{
    public static class Ensure
    {
#if Expressions_Supported
        /// <summary>
        /// Determine whether the object is null, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the object to be checked.</param>
        public static IEnsurable<T> NotNull<T>(Expression<Func<T>> valueExpression) where T : class
        {
            if (valueExpression == null)
            {
                throw new ArgumentException("Expression cannot be null.");
            }

            ConstantExpression constantExpression = valueExpression.Body as ConstantExpression;
            if (constantExpression != null)
            {
                return NotNull((T)constantExpression.Value, "Variable");
            }

            MemberExpression memberExpression = valueExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression must be of type MemberExpression.");
            }

            T value = (T)Expression.Lambda(memberExpression).Compile().DynamicInvoke();
            string variableName = string.IsNullOrEmpty(memberExpression.Member.Name) ? "Variable" : memberExpression.Member.Name;

            return NotNull(value, variableName);
        }

        /// <summary>
        /// Determine whether the string is null or empty, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the string to be checked.</param>
        public static IEnsurable<string> NotNullOrEmpty(Expression<Func<string>> valueExpression)
        {
            if (valueExpression == null)
            {
                throw new ArgumentException("Expression cannot be null.");
            }

            ConstantExpression constantExpression = valueExpression.Body as ConstantExpression;
            if (constantExpression != null)
            {
                return NotNullOrEmpty((string)constantExpression.Value, "Variable");
            }

            MemberExpression memberExpression = valueExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression must be of type MemberExpression.");
            }

            string value = (string)Expression.Lambda(memberExpression).Compile().DynamicInvoke();
            string variableName = string.IsNullOrEmpty(memberExpression.Member.Name) ? "Variable" : memberExpression.Member.Name;

            return NotNullOrEmpty(value, variableName);
        }

        /// <summary>
        /// Determine whether the object has a default value, if so throws an appropriate exception depending on the input.
        /// </summary>
        /// <param name="valueExpression">Expression with the object to be checked.</param>
        public static IEnsurable<T> NotDefault<T>(Expression<Func<T>> valueExpression)
        {
            if (valueExpression == null)
            {
                throw new ArgumentException("Expression cannot be null.");
            }

            ConstantExpression constantExpression = valueExpression.Body as ConstantExpression;
            if (constantExpression != null)
            {
                return NotDefault((T)constantExpression.Value, "Variable");
            }

            MemberExpression memberExpression = valueExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression must be of type MemberExpression.");
            }

            T value = (T)Expression.Lambda(memberExpression).Compile().DynamicInvoke();
            string variableName = string.IsNullOrEmpty(memberExpression.Member.Name) ? "Variable" : memberExpression.Member.Name;

            return NotDefault(value, variableName);
        }
#endif
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