using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extension
{
    public static void ReflectY(this Vector2 source)
    {
        source.y *= -1;
    }

}
