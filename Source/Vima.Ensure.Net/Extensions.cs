using System.Collections;

namespace Vima.Ensure.Net;

internal static class Extensions
{
    internal static bool IsEmpty(IEnumerable source)
    {
        if (source is ICollection collection)
            return collection.Count == 0;

        IEnumerator enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            enumerator.Reset();
            return false;
        }

        return true;
    }
}