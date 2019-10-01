using Vima.Ensure.Net.Attributes;

namespace Vima.Ensure.Net
{
    public static partial class Ensure
    {
        /// <summary>
        /// Determine whether the object is null, if so throws an ArgumentNullException.
        /// </summary>
        /// <param name="value">The object to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<T> NotNull<T>([ValidatedNotNull] T value, string parameterName = null) where T : class
        {
            CheckForNulls(value, parameterName);

            return new Ensurable<T>(value);
        }

        /// <summary>
        /// Determine whether the nullable struct is null, if so throws an ArgumentNullException.
        /// </summary>
        /// <param name="value">The nullable struct to be checked.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        public static IEnsurable<T> NotNull<T>([ValidatedNotNull] T? value, string parameterName = null)
            where T : struct
        {
            CheckForNulls(value, parameterName);

            return new Ensurable<T>(value.Value);
        }
    }
}