﻿using System;
using System.Collections;
using System.Collections.Generic;


public static class Utility 
{
    public static T[] ShuffleArray<T>(T[] array, int seed)
    {
        Random prng = new Random(seed);

        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = prng.Next(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }
        return array;
    }

    public static T ReturnRandomElem<T>(T[] array, int seed)
    {
        Random prng = new Random(seed);
        int randomIndex = prng.Next(0, array.Length);
        return array[randomIndex];
    }

}
