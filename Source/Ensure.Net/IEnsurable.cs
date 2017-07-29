namespace Ensure.Net
{
    public interface IEnsurable<T>
    {
        T Value { get; set; }
    }

    public class Ensurable<T> : IEnsurable<T>
    {
        public Ensurable(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}