using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Utility 
{
    public static T[] ShuffleArray<T>(T[] array, int seed)
    {
        System.Random prng = new System.Random(seed);

        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = prng.Next(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }
        return array;
    }

    public static Vector3 ScreenToWorldPos(Camera camera, Vector3 position)
    {
        Debug.Log(camera);
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }



}
