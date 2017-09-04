namespace Vima.Ensure.Net
{
    public interface IEnsurable<T>
    {
        T Value { get; set; }
    }
}