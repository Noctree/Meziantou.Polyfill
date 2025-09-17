using System;
using System.Collections;
using System.Collections.Generic;

static partial class PolyfillExtensions
{
    public static bool TryGetNonEnumeratedCount<TSource>(this IEnumerable<TSource> source, out int count)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (source is ICollection<TSource> collectionOfT)
        {
            count = collectionOfT.Count;
            return true;
        }

        if (source is ICollection collection)
        {
            count = collection.Count;
            return true;
        }

        count = 0;
        return false;
    }
}
