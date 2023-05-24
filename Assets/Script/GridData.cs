using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridData : MonoBehaviour
{
    public string[] GridCollision = new string[20];
    public Sprite[] Names = new Sprite[20];
    public Tilemap tilemap;
    TileBase tile_;

    void Start()
    {
        for (int j = 0; j < GridCollision.Length; j++)
        {
            for (int i = 0; i < 30; i++)
            {
                TileBase tile = tilemap.GetTile(tilemap.LocalToCell(new Vector3(j-5, i-15)));

                if (tile != null)
                {
                    string a = tile.ToString();
                    string[] word = a.Split(" ");
                    Debug.Log($"/{a}/");

                    bool act = false;
                    for (int h = 0; h < Names.Length; h++)
                    {
                        if (Names[h].ToString().Contains(word[0]))
                        {
                            act = true;
                        }
                    }

                    if (act == true)
                    {
                        GridCollision[j] += '1';
                    }
                    else
                    {
                        GridCollision[j] += '0';
                    }
                }
                else
                {
                    GridCollision[j] += '0';
                }
            }
        }
    }


}
