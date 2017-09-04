using System.Collections;
using System.Collections.Generic;

 namespace Vima.Ensure.Net
{
    internal static class Extensions
    {
        internal static long GetCount<T>(IEnumerable<T> source)
        {
            switch (source)
            {
                case ICollection<T> genericCollection:
                    return genericCollection.Count;
                case ICollection collection:
                    return collection.Count;
            }

            long count = 0;
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    checked { ++count; }
                }
            }
            return count;
        }
    }
}