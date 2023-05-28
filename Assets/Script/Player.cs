using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GridData gridData;

    public Vector2Int Position;
    public float Offset;

    public Vector3 previuspos;

    public Character stats;
    public int LifePoints;
    public int ArmorPoints;
    public int DamagePoints;

    private void Start()
    {
        stats = new Character(LifePoints, ArmorPoints, DamagePoints);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(-1, 0);
        }

        transform.position = new Vector3(Position.x + Offset, Position.y + Offset);



        //JETROUVERAIUNNOMPLUSTARD();
    }

    
    private void Move(int x, int y)
    {
        if (gridData.isBlocked[Position.x + x, Position.y + y] == false)
            Position = new Vector2Int(Position.x + x, Position.y + y);
        else if (gridData.EnnemiPosNStats[Position.x + x, Position.y + y] != null)
        {
            stats.Battle(gridData.EnnemiPosNStats[Position.x + x, Position.y + y]);
            Debug.Log("ecsecsec");
        }
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