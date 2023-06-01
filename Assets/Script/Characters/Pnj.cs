using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pnj : BasiquePos
{
    public Pnj(Vector2Int p, float o) : base(p, o)
    {
    }

    Pnj pnj;

    public GameObject DialogBox;
    Text text;

    private void Start()
    {
        pnj.Position = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        pnj.Offset = 0.5f;

        DialogBox.SetActive(false);
    }

    public void Dialog(GameObject Player)
    {
        Player player = Player.GetComponent<Player>();
        player.Dialog = true;

        DialogBox.SetActive(true);
        text.text = @$"Money for heal !
1 coin => 5 life points
Press Space";
    }
}
