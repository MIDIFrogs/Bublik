using System.Collections.Generic;
using UnityEngine;

public static class LinqUtils
{
    public static T RandomChoice<T>(this IReadOnlyList<T> items) => items[Random.Range(0, items.Count)];
}
