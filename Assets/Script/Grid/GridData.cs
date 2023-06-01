using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridData : MonoBehaviour
{
    private static GridData instance = null;
    public static GridData Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public Tilemap tilemap;
    public TileBase _tile;

    public Vector2Int MapSize;
    public Vector2Int[] BlockedCells;
    public Vector2Int[] EnnemiesCells;
    public Vector2Int[] DropCells;
    public Vector2Int[] PotCells;
    public Vector2Int[] VortexCells;

    [SerializeField]
    private GameObject PrefabVortex;
    public GameObject[] vortex;

    public bool[,] isBlocked;
    public GameObject[,] ObjAffPos;

    [SerializeField]
    private GameObject PrefabBigPot;
    [SerializeField]
    private GameObject PrefabLittlePot;
    public GameObject[] Pot;

    public Vector2 OriginPosition;

    public GameObject PrefabEnnemy;
    public GameObject[] Ennemy;
    public Vector2 OriginPositionEnnemy;

    private void Start()
    {
        isBlocked = new bool[MapSize.x,MapSize.y];
        ObjAffPos = new GameObject[MapSize.x,MapSize.y];

        Pot = new GameObject[PotCells.Length];
        Ennemy = new GameObject[EnnemiesCells.Length];
        vortex = new GameObject[VortexCells.Length];

        for (int y = MapSize.y-1; y >= 0; y--)
        {
            for (int x = 0; x < MapSize.x; x++)
            {
                isBlocked[x, y] = false;
            }
        }

        foreach (var cell in BlockedCells)
        {
            isBlocked[cell.x, cell.y] = true;
        }

        for (int i = 0; i < VortexCells.Length; i++)
        {
            vortex[i] = Instantiate(PrefabVortex, new Vector3(VortexCells[i].x + 0.5f, VortexCells[i].y + 0.5f, 0), Quaternion.Euler(0, 0, 0));

            ObjAffPos[VortexCells[i].x, VortexCells[i].y] = vortex[i];
        }

        for (int i = 0; i < VortexCells.Length; i+=2)
        {
            if (i + 1 < VortexCells.Length)
            {
                vortex[i].GetComponent<Vortex>().VortexEnd = vortex[i + 1];
                vortex[i + 1].GetComponent<Vortex>().VortexEnd = vortex[i];
            }
        }


        for (int i = 0; i < EnnemiesCells.Length; i++)
        {
            Ennemy[i] = Instantiate(PrefabEnnemy, new Vector3(EnnemiesCells[i].x + 0.5f, EnnemiesCells[i].y + 0.5f, 0), Quaternion.Euler(0, 0, 0));

            ObjAffPos[EnnemiesCells[i].x, EnnemiesCells[i].y] = Ennemy[i];
        }

        for (int i = 0; i < PotCells.Length; i++)
        {
            Pot pot = null;
            int random = UnityEngine.Random.Range(0, 2);

            if (random == 0)
            {
                Pot[i] = Instantiate(PrefabBigPot, new Vector3(PotCells[i].x + 0.5f, PotCells[i].y + 0.5f, 0), Quaternion.Euler(0, 0, 0));
            }
            if (random == 1)
            {
                Pot[i] = Instantiate(PrefabLittlePot, new Vector3(PotCells[i].x + 0.5f, PotCells[i].y + 0.5f, 0), Quaternion.Euler(0, 0, 0));
            }

            ObjAffPos[PotCells[i].x, PotCells[i].y] = Pot[i];
        }

        EdgeInit();
    }




    private void EdgeInit()
    {
        for (int y = 0; y < MapSize.y; y++)
        {
            isBlocked[0, y] = true;
            isBlocked[MapSize.x - 1, y] = true;
        }

        for (int x = 0; x < MapSize.x; x++)
        {
            isBlocked[x, 0] = true;
            isBlocked[x, MapSize.y - 1] = true;
        }
    }
}