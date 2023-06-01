using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int Gain = 1;

    public Coin(Vector2Int p, float o, int G) : base(p,o)
    {
        Gain = G;
    }

    public void CheckPos(GameObject Player)
    {
        if (Position == gameObject.GetComponent<Coin>().Position)
        {
            Player.GetComponent<Player>().Coin += Gain;
            Destroy(gameObject);
        }
    }
}
