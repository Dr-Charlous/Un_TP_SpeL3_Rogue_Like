using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GridData gridData;

    public Vector2Int Position;
    public float Offset;

    public GameObject PotionPrefab;
    public GameObject CoinPrefab;
    public GameObject VortexPrefab;

    public Vector3 previuspos;

    public int Life;
    public int InitLife;
    public int Armor;
    public int Damage;
    public int Coin;
    public int Lvl;
    public int XP;
    public bool Attacked;

    private void Start()
    {
        Life = 10;
        InitLife = 10;
        Armor = 4;
        Damage = 6;
        Coin = 0;
        Lvl = 1;
        XP = 0;
        Attacked = false;
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



        JETROUVERAIUNNOMPLUSTARD();
    }

    
    private void Move(int x, int y)
    {
        if (gridData.EnnemiPos[Position.x + x, Position.y + y] != null)
        {
            Battle(gridData.EnnemiPos[Position.x + x, Position.y + y]);
        }
        else if (gridData.PotPos[Position.x + x, Position.y + y] != null)
        {
            gridData.PotPos[Position.x + x, Position.y + y].GetComponent<Pot>().Move(x, y);
        }
        else if (gridData.isBlocked[Position.x + x, Position.y + y] == false)
            Position = new Vector2Int(Position.x + x, Position.y + y);

        if (gridData.DropPos[Position.x, Position.y] != null)
        {
            if (gridData.DropPos[Position.x, Position.y].name == $"{PotionPrefab.name}(Clone)")
            {
                Life += 5;
                if (Life > InitLife)
                    Life = InitLife;
                Destroy(gridData.DropPos[Position.x, Position.y]);
            }
            else if (gridData.DropPos[Position.x, Position.y].name == $"{CoinPrefab.name}(Clone)")
            {
                Coin += 1;
                Destroy(gridData.DropPos[Position.x, Position.y]);
            }
        }

        bool arround = false;
        for (int x_ = -1; x_ <= 1; x_++)
        {
            for (int y_ = -1; y_ <= 1; y_++)
            {
                if (gridData.EnnemiPos[Position.x + x_, Position.y + y_] != null)
                {
                    if (Attacked == false)
                    {
                        Life -= gridData.EnnemiPos[Position.x + x_, Position.y + y_].GetComponent<Ennemi>().Damage - Armor;
                        Attacked = true;
                    }
                    arround = true;
                }
            }
        }
        if (arround == false)
            Attacked = false;
    }

    public void Battle(GameObject e)
    {
        if (Damage > e.GetComponent<Ennemi>().Armor)
            e.GetComponent<Ennemi>().Life -= Damage - e.GetComponent<Ennemi>().Armor;

        if (e.GetComponent<Ennemi>().Life <= 0)
        {
            int random = UnityEngine.Random.Range(0, 10);
            if (random < 3)
            {
                GameObject Potion = Instantiate(PotionPrefab, e.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
                gridData.DropPos[(int)e.transform.position.x, (int)e.transform.position.y] = Potion;
            }
            else if (random < 6)
            {
                GameObject Coin = Instantiate(CoinPrefab, e.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                gridData.DropPos[(int)e.transform.position.x, (int)e.transform.position.y] = Coin;
            }

            Destroy(e);

            XPDrop(Lvl, XP);
        }

        if (e.GetComponent<Ennemi>().Damage > Armor)
            Life -= e.GetComponent<Ennemi>().Damage - Armor;

        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void XPDrop(int lvl, int xp)
    {
        int randomXP = UnityEngine.Random.Range(2, 5);
        XP += randomXP;

        if (xp >= (lvl*8) && lvl < 5)
        {
            XP = 0;
            Lvl += 1;

            InitLife += 2;
            Life += 2;
            Damage += 2;
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