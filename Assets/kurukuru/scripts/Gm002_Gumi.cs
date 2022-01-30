using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm002_Gumi : GimmickBase
{
	private Rigidbody2D _rigidbody2D;
	private SpriteRenderer _spriteRenderer;
	private CircleCollider2D _collider;

	private float _time;
	private int _spriteCount;

	[SerializeField] private float animationInterval = 0.2f;
	[SerializeField] private PhysicsMaterial2D physicsMaterial;
	[SerializeField] private List<Sprite> spriteList = new List<Sprite>();

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
		_time += Time.deltaTime;
		if (_time > animationInterval)
		{
			_spriteCount++;
			if (_spriteCount >= spriteList.Count)
				_spriteCount = 0;

			_spriteRenderer.sprite = spriteList[_spriteCount];
		}
	}

	public override void Enter(GimmickID prev)
	{
		base.Enter(prev);

		// 回転を有効にします。
		_rigidbody2D.constraints = RigidbodyConstraints2D.None;

		gameObject.tag = "Soft";

		_spriteRenderer.sprite = spriteList[0];

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