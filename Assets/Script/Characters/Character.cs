using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : BasiquePos
{
    public int LifePoints { set; get; }
    public int ArmorPoints { set; get; }
    public int DamagePoints { set; get; }

    public Character(Vector2Int p, float o, int l, int a, int d) : base (p, o)
    {
        LifePoints = l;
        ArmorPoints = a;
        DamagePoints = d;
    }

    public void XPDrop(Player player, int lvl, int xp)
    {
        int randomXP = UnityEngine.Random.Range(2, 5);
        player.XP += randomXP;

        if (xp >= (lvl * 8) && lvl < 5)
        {
            player.XP = 0;
            player.Lvl += 1;

            player.InitLife += 2;
            player.LifePoints += 2;
            player.DamagePoints += 2;
        }
    }

    public void Battle(Ennemi ennemi, Player player)
    {
        if (player.DamagePoints > ennemi.ArmorPoints)
            ennemi.LifePoints -= player.DamagePoints - ennemi.ArmorPoints;

        ennemi.Hit(ennemi, player, ennemi.gameObject);

        if (ennemi.DamagePoints > player.ArmorPoints)
            player.LifePoints -= ennemi.DamagePoints - player.ArmorPoints;

        if (player.LifePoints <= 0)
        {
            Destroy(player.gameObject);
        }
    }
}
