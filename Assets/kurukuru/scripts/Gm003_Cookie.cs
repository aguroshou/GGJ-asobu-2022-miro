using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm003_Cookie : GimmickBase
{
	public override GimmickID ID { get { return GimmickID.Cookie; } }

	private Rigidbody2D _rigidbody2D;
	private SpriteRenderer _spriteRenderer;
	private BoxCollider2D _collider;

	[SerializeField] Sprite sprite;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_collider = GetComponent<BoxCollider2D>();
	}

	void Update()
	{

	}

	public override void Enter(GimmickID prev)
	{
		base.Enter(prev);

		//横移動を常に停止します。
		_rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

		this.gameObject.tag = "Ground";

		_spriteRenderer.sprite = sprite;

		_collider.enabled = true;

		transform.localRotation = Quaternion.identity;
	}

	public override void Exit(GimmickID next)
	{
		base.Exit(next);

		//横移動の停止を解除します。
		_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

		_collider.enabled = false;
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
					SoundManager.I.PlaySE(SoundManager.SE.Cookie);
					Debug.Log(gameObject.name);
					Destroy(gameObject);
				}
			}
		}
	}
}
