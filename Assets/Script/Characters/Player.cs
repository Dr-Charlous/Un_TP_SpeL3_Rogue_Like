using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    public Player(Vector2Int p, float o, int l, int a, int d) : base (p, o, l, a, d)
    {

    }

    public GameObject PotionPrefab;
    public GameObject CoinPrefab;
    public GameObject VortexPrefab;

    public Player player;

    public int InitLife;
    public int Coin;

    public int Lvl;
    public int XP;
    private bool Attacked;


    private void Start()
    {
        player.Position = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        player.Offset = 0.5f;
        player.LifePoints = 15;
        player.ArmorPoints = 5;
        player.DamagePoints = 5;

        InitLife = player.LifePoints;

        Coin = 0;

        Lvl = 1;
        XP = 0;

        Attacked = false;
    }

    public void Update()
    {
        Player player = gameObject.GetComponent<Player>();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(0, 1, player);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(0, -1, player);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(1, 0, player);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(-1, 0, player);
        }

        transform.position = new Vector3(Position.x + Offset, Position.y + Offset);
    }

    
    private void Move(int x, int y, Player player)
    {
        print(LifePoints);

        if (GridData.Instance.isBlocked[Position.x + x, Position.y + y] == false)
        {            
            if (GridData.Instance.ObjAffPos[Position.x + x, Position.y + y] != null)
            {
                if (GridData.Instance.ObjAffPos[Position.x + x, Position.y + y].TryGetComponent<Ennemi>(out Ennemi ennemi))
                {
                    Battle(ennemi, player);
                }
                else if (GridData.Instance.ObjAffPos[Position.x + x, Position.y + y].TryGetComponent<Pot>(out Pot pot))
                {
                    pot.Move(x, y);
                }
                else if (GridData.Instance.ObjAffPos[Position.x + x, Position.y + y].TryGetComponent<Vortex>(out Vortex vortex))
                {
                    Position = new Vector2Int(Position.x + x, Position.y + y);
                    vortex.CheckPos(gameObject);
                }
                else if (GridData.Instance.ObjAffPos[Position.x + x, Position.y + y].TryGetComponent<Coin>(out Coin coin))
                {
                    Position = new Vector2Int(Position.x + x, Position.y + y);
                    coin.CheckPos(gameObject);
                }
                else if (GridData.Instance.ObjAffPos[Position.x + x, Position.y + y].TryGetComponent<Potion>(out Potion potion))
                {
                    Position = new Vector2Int(Position.x + x, Position.y + y);
                    potion.CheckPos(gameObject);
                }
            }
            else
            {
                Position = new Vector2Int(Position.x + x, Position.y + y);
            }
        }

        Hit();
    }

    public void Hit()
    {
        bool arround = false;

        for (int x_ = -1; x_ <= 1; x_++)
        {
            for (int y_ = -1; y_ <= 1; y_++)
            {
                if (GridData.Instance.ObjAffPos[Position.x + x_, Position.y + y_] != null && GridData.Instance.ObjAffPos[Position.x + x_, Position.y + y_].TryGetComponent<Ennemi>(out Ennemi ennemi))
                {
                    if (Attacked == false)
                    {
                        player.LifePoints -= ennemi.DamagePoints - player.ArmorPoints;
                        Attacked = true;
                    }
                    arround = true;
                }
            }
        }

        if (arround == false)
            player.Attacked = false;
    }
}