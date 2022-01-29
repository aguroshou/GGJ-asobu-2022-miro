using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm001_Ame : GimmickBase
{
	public override GimmickID ID { get { return GimmickID.Ame; } }

	void Update()
	{

	}

	public override void Enter(GimmickID prev)
	{
		base.Enter(prev);

		this.gameObject.tag = "Ground";
		var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.yellow;
	}

	public override void Exit(GimmickID next)
	{
		base.Exit(next);
	}
}
