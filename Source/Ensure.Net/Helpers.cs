using System.Collections;
using System.Collections.Generic;

namespace Ensure.Net
{
    public static class Helpers
    {
        public static long GetCount<T>(IEnumerable<T> source)
        {
            ICollection<T> sources = source as ICollection<T>;
            if (sources != null)
            {
                return sources.Count;
            }

            ICollection collection = source as ICollection;
            if (collection != null)
            {
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