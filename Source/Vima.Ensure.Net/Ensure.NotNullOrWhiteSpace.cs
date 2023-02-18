using System;
using Vima.Ensure.Net.Attributes;

namespace Vima.Ensure.Net;

public static partial class Ensure
{
    /// <summary>
    /// Checks whether <see cref="string"/> value is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <exception cref="ArgumentNullException">Thrown when specified <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when specified <paramref name="value"/> is empty.</exception>
    public static IEnsurable<string> NotNullOrWhiteSpace(
        [ValidatedNotNull] string? value,
        string? parameterName = null)
    {
        string nonNullValue = ThrowExceptionIfStringIsNullOrEmpty(value, parameterName);

        foreach (var character in nonNullValue)
        {
            if (!char.IsWhiteSpace(character))
                return new Ensurable<string>(nonNullValue);
        }

        throw new ArgumentException(
            $"{parameterName ?? DefaultParameterName} cannot contain only white space characters.");
    }
}