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

        // 回転を有効にします。
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.None;

        this.gameObject.tag = "Soft";
        var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }

    public override void Exit(GimmickID next)
    {
        // 回転を無効にします。
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        base.Exit(next);
    }
}