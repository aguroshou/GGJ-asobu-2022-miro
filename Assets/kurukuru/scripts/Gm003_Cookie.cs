using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm003_Cookie : GimmickBase
{
	public override GimmickID ID { get { return GimmickID.Cookie; } }

	void Update()
	{

	}

	public override void Enter(GimmickID prev)
	{
		base.Enter(prev);

		this.gameObject.tag = "Ground";
		var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.grey;
	}

	public override void Exit(GimmickID next)
	{
		base.Exit(next);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (enabled == false)
			return;

		var gm = collision.gameObject.GetComponent<GimmickChanger>();
		if (gm != null)
		{
			if (gm.CurrentID == GimmickID.Ame)
			{
				if (gameObject != null)
				{

					Debug.Log(gameObject.name);
					Destroy(gameObject);
				}
			}
		}
	}
}
