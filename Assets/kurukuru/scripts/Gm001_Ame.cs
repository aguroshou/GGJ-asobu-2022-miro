using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm001_Ame : GimmickBase
{
	public override GimmickID ID { get { return GimmickID.Ame; } }

	private GroundSoftCheck _groundSoftCheck;
	private Rigidbody2D _rigidbody2D;
	private SpriteRenderer _spriteRenderer;
	private CircleCollider2D _collider;

	private float _time;
	private int _spriteCount;

	[SerializeField] private float animationInterval = 0.2f;
	[SerializeField] private float softOrHardGimmickHighJumpPower = 8.0f;
	[SerializeField] private List<Sprite> spriteList = new List<Sprite>();
	[SerializeField] private PhysicsMaterial2D physicsMaterial;

	Vector3 _groundCheckPos;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_collider = GetComponent<CircleCollider2D>();
		_groundSoftCheck = GetComponentInChildren<GroundSoftCheck>();
	}

	private void Start()
	{
		_groundCheckPos = transform.position - _groundSoftCheck.transform.position;
	}

	void Update()
	{
		//床が高くジャンプできるブロックであるかを判別します。
		if (_groundSoftCheck.IsGroundSoft())
		{
			_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, softOrHardGimmickHighJumpPower);
			_groundSoftCheck.PlayerJumped();

			SoundManager.I.PlaySE(SoundManager.SE.Jump02);
		}

		_time += Time.deltaTime;
		if (_time > animationInterval)
		{
			_spriteCount++;
			if (_spriteCount >= spriteList.Count)
				_spriteCount = 0;

			_spriteRenderer.sprite = spriteList[_spriteCount];
			_time = 0.0f;
		}
	}

	private void LateUpdate()
	{
		_groundSoftCheck.transform.position = transform.position - _groundCheckPos;
		_groundSoftCheck.transform.rotation = Quaternion.identity;
	}

	public override void Enter(GimmickID prev)
	{
		base.Enter(prev);

		this.gameObject.tag = "Ground";

		_spriteRenderer.sprite = spriteList[0];

		// 回転を有効にします。
		_rigidbody2D.constraints = RigidbodyConstraints2D.None;

		_rigidbody2D.sharedMaterial = physicsMaterial;

		_collider.enabled = true;
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
