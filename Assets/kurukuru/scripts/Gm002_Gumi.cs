using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm002_Gumi : GimmickBase
{
	public override GimmickID ID { get { return GimmickID.Gumi; } }

	void Update()
	{

	}

	public override void Enter(GimmickID prev)
	{
		base.Enter(prev);

		this.gameObject.tag = "Soft";
		var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.red;
	}

	public override void Exit(GimmickID next)
	{
		base.Exit(next);
	}
}
