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

		//横移動を常に停止します。
		Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
		rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		
		this.gameObject.tag = "Ground";
		var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color(255.0f / 255.0f, 138.0f / 255.0f, 0.0f);
	}

	public override void Exit(GimmickID next)
	{
		//横移動の停止を解除します。
		Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
		rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

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
