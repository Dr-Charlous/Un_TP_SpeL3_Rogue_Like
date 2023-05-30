using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridData : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase _tile;

    public Vector2Int MapSize;
    public Vector2Int[] BlockedCells;
    public Vector2Int[] EnnemiCells;
    public Vector2Int[] DropCells;
    public Vector2Int[] PotCells;

    public bool[,] isBlocked;
    public GameObject[,] EnnemiPos;
    public GameObject[,] DropPos;
    public GameObject[,] PotPos;

    public GameObject PrefabPot;
    public GameObject[] Pot;

    public GameObject PrefabPlayer;
    public GameObject Player;
    public Vector2 OriginPosition;

    public GameObject PrefabEnnemy;
    public GameObject[] Ennemy;
    public Vector2 OriginPositionEnnemy;

    private void Start()
    {
        isBlocked = new bool[MapSize.x,MapSize.y];
        EnnemiPos = new GameObject[MapSize.x,MapSize.y];
        DropPos = new GameObject[MapSize.x,MapSize.y];
        PotPos = new GameObject[MapSize.x,MapSize.y];
        Pot = new GameObject[PotCells.Length];
        Ennemy = new GameObject[EnnemiCells.Length];

        for (int y = MapSize.y-1; y >= 0; y--)
        {
            for (int x = 0; x < MapSize.x; x++)
            {
                isBlocked[x, y] = false;
            }
        }

        foreach (var cells in BlockedCells)
        {
            isBlocked[cells.x,cells.y] = true;
        }

        for (int i = 0; i < EnnemiCells.Length; i++)
        {
            Ennemy[i] = Instantiate(PrefabEnnemy, new Vector3(EnnemiCells[i].x + 0.5f, EnnemiCells[i].y + 0.5f, 0), Quaternion.Euler(0, 0, 0));

            Ennemy[i].GetComponent<Ennemi>().Life = 10;
            Ennemy[i].GetComponent<Ennemi>().Armor = 5;
            Ennemy[i].GetComponent<Ennemi>().Damage = 3;

            EnnemiPos[EnnemiCells[i].x, EnnemiCells[i].y] = Ennemy[i];
        }

        for (int i = 0; i < PotCells.Length; i++)
        {
            Pot[i] = Instantiate(PrefabPot, new Vector3(PotCells[i].x + 0.5f, PotCells[i].y + 0.5f, 0), Quaternion.Euler(0, 0, 0));

            Pot[i].GetComponent<Pot>().Offset = 0.5f;

            PotPos[PotCells[i].x, PotCells[i].y] = Pot[i];
        }

        EdgeInit();

        //Player = Instantiate(PrefabPlayer, new Vector3(OriginPosition.x + 0.5f, OriginPosition.y + 0.5f, 0), Quaternion.Euler(0, 0, 0));
        //Player.GetComponent<Player>().Position = new Vector2Int((int)OriginPosition.x, (int)OriginPosition.y);
        Player.GetComponent<Player>().Offset = 0.5f;

    }




    private void EdgeInit()
    {
        for (int y = 0; y < MapSize.y; y++)
        {
            tilemap.SetTile(new Vector3Int(0, y, 0), _tile);
            tilemap.SetTile(new Vector3Int(MapSize.x-1, y, 0), _tile);

            isBlocked[0, y] = true;
            isBlocked[MapSize.x - 1, y] = true;
        }

        for (int x = 0; x < MapSize.x; x++)
        {
            tilemap.SetTile(new Vector3Int(x, 0, 0), _tile);
            tilemap.SetTile(new Vector3Int(x, MapSize.y-1, 0), _tile);

            isBlocked[x, 0] = true;
            isBlocked[x, MapSize.y - 1] = true;
        }
    }
}