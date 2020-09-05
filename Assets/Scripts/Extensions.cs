using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool Find<T>(this List<T> original, System.Predicate<T> match, out T element)
    {
        element = original.Find(match);
        return element != null;
    }
}
