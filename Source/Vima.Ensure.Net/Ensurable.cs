namespace Vima.Ensure.Net;

internal class Ensurable<T> : IEnsurable<T>
{
    internal Ensurable(T value)
    {
        Value = value;
    }

    public T Value { get; set; }
}