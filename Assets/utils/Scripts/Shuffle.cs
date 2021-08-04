using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shuffle
{
    public static void ShuffleArray<T>(T[] array)
    {
        int random1;
        int random2;
 
        T tmp;
 
        for (int index = 0; index < array.Length; ++index)
        {
            random1 = UnityEngine.Random.Range(0, array.Length);
            random2 = UnityEngine.Random.Range(0, array.Length);
 
            tmp = array[random1];
            array[random1] = array[random2];
            array[random2] = tmp;
        }
    }
}
