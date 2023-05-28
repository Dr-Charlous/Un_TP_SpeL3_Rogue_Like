using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public Vector2Int Position;
    public float Offset;

    //int action = 0;

    private void Start()
    {
        //StartCoroutine(IA());
    }






    //public IEnumerator IA()
    //{
    //    action = Random.Range(0, 3);
    //    Move(action);
    //    yield return new WaitForSeconds(1);
    //    StartCoroutine(IA());
    //}

    //public void Move(int a)
    //{
    //    if (a == 0)
    //    {
    //        if (GridData.gridData.isBlocked[Position.x, Position.y + 1] == false)
    //            Position = new Vector2Int(Position.x, Position.y + 1);
    //    }
    //    else if (a == 1)
    //    {
    //        if (GridData.gridData.isBlocked[Position.x, Position.y - 1] == false)
    //            Position = new Vector2Int(Position.x, Position.y - 1);
    //    }
    //    else if (a == 2)
    //    {
    //        if (GridData.gridData.isBlocked[Position.x + 1, Position.y] == false)
    //            Position = new Vector2Int(Position.x + 1, Position.y);
    //    }
    //    else if (a == 3)
    //    {
    //        if (GridData.gridData.isBlocked[Position.x - 1, Position.y] == false)
    //            Position = new Vector2Int(Position.x - 1, Position.y);
    //    }

    //    transform.position = new Vector3(Position.x + Offset, Position.y + Offset);
    //}
}
