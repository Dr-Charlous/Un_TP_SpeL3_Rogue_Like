using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public GridData gridData;
    public GameObject Player;

    public Vector2Int Position;
    public float Offset;

    public void Start()
    {
        gridData = GameObject.FindGameObjectWithTag("grid").GetComponent<GridData>();
        Player = GameObject.FindGameObjectWithTag("player");
        Position = new Vector2Int((int)transform.position.x, (int)transform.position.y);
    }

    public void Move(int x, int y)
    {
        if (gridData.isBlocked[Position.x + x, Position.y + y] == false)
        {
            gridData.PotPos[Position.x, Position.y] = null;

            Position = new Vector2Int(Position.x + x, Position.y + y);

            gridData.PotPos[Position.x, Position.y] = this.gameObject;
        }

        transform.position = new Vector3(Position.x + Offset, Position.y + Offset);
    }
}
