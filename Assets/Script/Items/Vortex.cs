using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : Item
{
    GameObject player;
    public GameObject VortexEnd;

    public Vortex(Vector2Int p, float o) : base(p, o)
    {
    }

    public void Start()
    {
        Position = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        GridData.Instance.ObjAffPos[Position.x, Position.y] = gameObject;
    }

    public void CheckPos(GameObject player)
    {
        if (Position == player.GetComponent<Player>().Position)
        {
            player.GetComponent<Player>().Position = new Vector2Int((int)VortexEnd.transform.position.x, (int)VortexEnd.transform.position.y);
        }
    }
}
