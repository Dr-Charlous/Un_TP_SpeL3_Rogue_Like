using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public int LifePoints { set; get; }
    public int ArmorPoints { set; get; }
    public int DamagePoints { set; get; }

    public Character(int l, int a, int d)
    {
        LifePoints = l;
        ArmorPoints = a;
        DamagePoints = d;
    }

    public void Battle(Character e)
    {
        e.LifePoints = DamagePoints - e.ArmorPoints;

        if (e.LifePoints <= 0)
        {
            
        }

        LifePoints = e.DamagePoints - ArmorPoints;

        if (LifePoints <= 0)
        {

        }

        Debug.Log("attaque finit");
    }
}
