using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public Vector3 previuspos;

    void Update()
    {
        JETROUVERAIUNNOMPLUSTARD();
    }

    private void JETROUVERAIUNNOMPLUSTARD()
    {
        if (transform.position != previuspos)
        {
            print(transform.position);
        }
        previuspos = transform.position;
    }
}
