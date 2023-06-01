using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasiquePos : MonoBehaviour
{
    public Vector2Int Position;
    public float Offset;

    public BasiquePos( Vector2Int p, float o)
    {
        Position = p;
        Offset = o;
    }
}
