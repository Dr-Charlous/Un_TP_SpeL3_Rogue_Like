using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : Character
{
    public Ennemi (Vector2Int p, float o, int l, int a, int d) : base(p, o, l, a, d)
    {
    }

    GameObject PotionPrefab;
    GameObject CoinPrefab;
    Ennemi ennemy;

    private void Start()
    {
        ennemy.Position = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        ennemy.Offset = 0.5f;
        ennemy.LifePoints = 10;
        ennemy.ArmorPoints = 3;
        ennemy.DamagePoints = 6;
    }

    public void Hit(Character ennemi, Player player, GameObject e)
    {
        if (ennemi.LifePoints <= 0)
        {
            int random = UnityEngine.Random.Range(0, 10);
            if (random < 3)
            {
                GameObject Potion = Instantiate(PotionPrefab, e.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                GridData.Instance.ObjAffPos[(int)e.transform.position.x, (int)e.transform.position.y] = Potion;
            }
            else if (random < 6)
            {
                GameObject Coin = Instantiate(CoinPrefab, e.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                GridData.Instance.ObjAffPos[(int)e.transform.position.x, (int)e.transform.position.y] = Coin;
            }

            Destroy(e);

            XPDrop(player, player.Lvl, player.XP);
        }
    }
}
