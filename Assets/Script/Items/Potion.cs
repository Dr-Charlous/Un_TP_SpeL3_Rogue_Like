using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    public int Heal = 1;

    public Potion(Vector2Int p, float o, int G) : base(p, o)
    {
        Heal = G;
    }

    public void CheckPos(GameObject Player)
    {
        if (Position == gameObject.GetComponent<Potion>().Position)
        {
            if (Player.GetComponent<Player>().LifePoints + Heal > Player.GetComponent<Player>().InitLife)
                Player.GetComponent<Player>().LifePoints = Player.GetComponent<Player>().InitLife;
            else
                Player.GetComponent<Player>().LifePoints += Heal;

            Destroy(gameObject);
        }
    }
}
