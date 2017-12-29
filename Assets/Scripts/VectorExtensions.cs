using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions{


    public static Vector2 To2DXY(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }
}
