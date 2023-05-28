using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridData : MonoBehaviour
{
    static public GridData gridData = new GridData();

    public Tilemap tilemap;
    public TileBase _tile;

    public Vector2Int MapSize;
    public Vector2Int[] BlockedCells;
    public Vector2Int[] EnnemiCells;

    public bool[,] isBlocked;
    public Character[,] EnnemiPosNStats;



    public GameObject PrefabPlayer;
    public GameObject Player;
    public Vector2 OriginPosition;

    public GameObject PrefabEnnemy;
    public GameObject Ennemy;
    public Vector2 OriginPositionEnnemy;

    public void Awake()
    {
        gridData = this;
    }

    private void Start()
    {
        isBlocked = new bool[MapSize.x,MapSize.y];
        EnnemiPosNStats = new Character[MapSize.x,MapSize.y];

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

        EdgeInit();

        Player = Instantiate(PrefabPlayer, new Vector3(OriginPosition.x + 0.5f, OriginPosition.y + 0.5f, 0), Quaternion.Euler(0, 0, 0));
        Player.GetComponent<Player>().Position = new Vector2Int((int)OriginPosition.x, (int)OriginPosition.y);
        Player.GetComponent<Player>().Offset = 0.5f;

        foreach (var pos in EnnemiCells)
        {
            Ennemy = Instantiate(PrefabEnnemy, new Vector3(pos.x + 0.5f, pos.y + 0.5f, 0), Quaternion.Euler(0, 0, 0));

            Character stats = new Character(10, 5, 3);
            EnnemiPosNStats[pos.x, pos.y] = stats;
        }
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