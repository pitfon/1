using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    #region List
    public static T Random<T>(this List<T> original)
    {
        int index = UnityEngine.Random.Range(0, original.Count);
        return original[index];
    }

    public static List<T> Random<T>(this List<T> original, int amount)
    {
        List<T> randomElements = new List<T>();

        for (int i = 0; i < amount; i++)
        {
            int index = UnityEngine.Random.Range(0, original.Count);
            randomElements.Add(original[index]);
        }

        return randomElements;
    }

    public static bool Find<T>(this List<T> original, System.Predicate<T> match, out T element)
    {
        element = original.Find(match);
        return element != null;
    }
    #endregion

    #region Vector3
    public static Vector3 Random(this Vector3 min, Vector3 max)
    {
        float Random(float minimum, float maximum)
        {
            return UnityEngine.Random.Range(minimum, maximum > minimum ? maximum : minimum);
        }

        return new Vector3(Random(min.x, max.x), Random(min.y, max.y), Random(min.z, max.z));
    }
    #endregion

}
