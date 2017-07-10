using System;
#if !NET20
using System.Linq.Expressions;
#endif

namespace Ensure.Net
{
    public static class Ensure
    {
#if !NET20
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
                throw new ArgumentException(message);
            }
            return new Ensurable<T> { Value = value };
        }
#endif
    }
}
