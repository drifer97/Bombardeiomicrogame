using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensionMethods{
    public static bool isZero(this Vector2 v, float sqrEpsilon = Vector2.kEpsilon ){
        return v.sqrMagnitude <= sqrEpsilon ;
    }

    public static bool isZero(this Vector3 v, float sqrEpsilon = Vector3.kEpsilon ){
        return v.sqrMagnitude <= sqrEpsilon ;
    }
}