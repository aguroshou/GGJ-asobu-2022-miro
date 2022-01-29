using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm002_Gumi : GimmickBase
{
    public override GimmickID ID
    {
        get { return GimmickID.Gumi; }
    }

    void Update()
    {
    }

    public override void Enter(GimmickID prev)
    {
        base.Enter(prev);

        //横移動を常に停止します。
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        this.gameObject.tag = "Soft";
        var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }

    public override void Exit(GimmickID next)
    {
        //横移動の停止を解除します。
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        base.Exit(next);
    }
}