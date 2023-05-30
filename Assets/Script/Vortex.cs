using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    public GameObject VortexEnd;

    public GridData gridData;
    public GameObject Player;
    public bool Teleported;

    public Vector2Int Position;
    public float Offset;

    public void Start()
    {
        gridData = GameObject.FindGameObjectWithTag("grid").GetComponent<GridData>();
        Player = GameObject.FindGameObjectWithTag("player");
        Position = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        Teleported = false;
    }

    public void Update()
    {
        if (Player.GetComponent<Player>().Position == Position && Teleported == false)
        {
            Teleport(0, 0);
            VortexEnd.GetComponent<Vortex>().Teleported = true;
            Teleported = false;
        }
        else if (Player.GetComponent<Player>().Position != Position)
        {
            Teleported = false;
        }
    }

    public void Teleport(int x, int y)
    {
        Player.GetComponent<Player>().Position = new Vector2Int((int)VortexEnd.transform.position.x + x, (int)VortexEnd.transform.position.y + y);
    }
}
