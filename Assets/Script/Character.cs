using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private int LifePoints { set; get; }
    private int ArmorPoints { set; get; }
    private int DamagePoints { set; get; }

    public Character(int l, int a, int d)
    {
        LifePoints = l;
        ArmorPoints = a;
        DamagePoints = d;
    }
}
