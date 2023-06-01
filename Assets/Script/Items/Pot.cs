using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : Item
{
    public Pot (Vector2Int p, float o) : base(p, o)
    {
    }

    public void Start()
    {
        Position = new Vector2Int((int)transform.position.x, (int)transform.position.y);
    }

    public void Move(int x, int y)
    {
        if (GridData.Instance.isBlocked[Position.x + x, Position.y + y] == false && GridData.Instance.ObjAffPos[Position.x + x, Position.y + y] == null)
        {
            GridData.Instance.ObjAffPos[Position.x, Position.y] = null;

            Position = new Vector2Int(Position.x + x, Position.y + y);
            print(Position);

            GridData.Instance.ObjAffPos[Position.x, Position.y] = this.gameObject;
        }

        transform.position = new Vector3(Position.x + Offset, Position.y + Offset);
    }
}
