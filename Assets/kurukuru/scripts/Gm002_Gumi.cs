using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm002_Gumi : GimmickBase
{
	private Rigidbody2D _rigidbody2D;
	private SpriteRenderer _spriteRenderer;
	private CircleCollider2D _collider;

	[SerializeField] private PhysicsMaterial2D physicsMaterial;
	[SerializeField] Sprite sprite;

	public override GimmickID ID
	{
		get { return GimmickID.Gumi; }
	}

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_collider = GetComponent<CircleCollider2D>();
	}

	void Update()
	{
	}

	public override void Enter(GimmickID prev)
	{
		base.Enter(prev);

		// 回転を有効にします。
		_rigidbody2D.constraints = RigidbodyConstraints2D.None;

		gameObject.tag = "Soft";

		_spriteRenderer.sprite = sprite;

		_collider.enabled = true;

		_rigidbody2D.sharedMaterial = physicsMaterial;
	}

	public override void Exit(GimmickID next)
	{
		base.Exit(next);

		// 回転を無効にします。
		_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

		_collider.enabled = false;

		_rigidbody2D.sharedMaterial = null;
	}
}