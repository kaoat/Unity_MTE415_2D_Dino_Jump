using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtension
{
    public static float ReflectValue(this float source)
    {
        return source *= -1;
    }
}
