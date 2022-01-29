using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm004_Ice : GimmickBase
{
	[SerializeField] float _MeltSpeed = 0.01f;

	public override GimmickID ID { get { return GimmickID.Ice; } }

	float Timer = 0.0f;

	void Update()
	{
		Timer -= Time.deltaTime;
		if (Timer > 0.0f)
			return;

		transform.localScale -= Vector3.one * _MeltSpeed * Time.deltaTime;
	}

	public override void Enter(GimmickID prev)
	{
		base.Enter(prev);

		this.gameObject.tag = "Ground";
		var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.white;

		Timer = 3.0f;
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
