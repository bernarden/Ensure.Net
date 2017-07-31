namespace Ensure.Net
{
    public class Ensurable<T> : IEnsurable<T>
    {
        public Ensurable(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}