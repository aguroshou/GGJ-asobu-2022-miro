using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm001_Ame : GimmickBase
{
	public override GimmickID ID { get { return GimmickID.Ame; } }
	
	private GroundSoftCheck _groundSoftCheck;
	private Rigidbody2D _rigidbody2D;

	[SerializeField] private float softOrHardGimmickHighJumpPower = 8.0f;
	
	void Update()
	{

		//床が高くジャンプできるブロックであるかを判別します。
		if (_groundSoftCheck.IsGroundSoft())
		{
			_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, softOrHardGimmickHighJumpPower);
			_groundSoftCheck.PlayerJumped();
		}
	}

	public override void Enter(GimmickID prev)
	{
		base.Enter(prev);

		this.gameObject.tag = "Ground";
		var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.yellow;

		_rigidbody2D = GetComponent<Rigidbody2D>();

		// 子オブジェクトにGroudSoftCheckのスクリプトを追加する必要があります。
		_groundSoftCheck = GetComponentInChildren<GroundSoftCheck>();
		
		// 回転を有効にします。
		Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
		rigidbody2D.constraints = RigidbodyConstraints2D.None;

	}

	public override void Exit(GimmickID next)
	{
		// 回転を無効にします。
		Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
		rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

		base.Exit(next);
	}
}
