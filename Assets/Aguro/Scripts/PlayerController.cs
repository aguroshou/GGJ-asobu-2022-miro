using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private float playerSpeed = 2.0f;
	[SerializeField] private float playerHighJumpPower = 8.0f;
	[SerializeField] private float playerJumpPower = 5.0f;
	[SerializeField] private GroundCheck groundCheck;
	[SerializeField] private GroundSoftCheck groundSoftCheck;

	private Animator _animator;
	private Rigidbody2D _rigidbody2D;
	private bool _isGround = false;
	private bool _isGroundSoft = false;
	private bool _isJumping = false;
	private bool _isMove = false;
	private SpriteRenderer _spriteRenderer;

	// Start is called before the first frame update
	void Start()
	{
		_animator = player.GetComponent<Animator>();
		_rigidbody2D = player.GetComponent<Rigidbody2D>();
		_spriteRenderer = player.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		//接地判定を得る
		_isGround = groundCheck.IsGround();

		//床が高くジャンプできるブロックであるかを判別します。
		_isGroundSoft = groundSoftCheck.IsGroundSoft();

		if (Input.GetKey(KeyCode.A))
		{
			_spriteRenderer.flipX = false;
			_rigidbody2D.velocity = new Vector2(-playerSpeed, _rigidbody2D.velocity.y);
			_isMove = true;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			_spriteRenderer.flipX = true;
			_rigidbody2D.velocity = new Vector2(playerSpeed, _rigidbody2D.velocity.y);
			_isMove = true;
		}
		else
		{
			_rigidbody2D.velocity = new Vector2(0.0f, _rigidbody2D.velocity.y);
			_isMove = false;
		}

		UpdateAnimation();

		if (Input.GetKeyDown(KeyCode.W))
		{
			if (_isGroundSoft)
			{
				_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, playerHighJumpPower);
				groundCheck.PlayerJumped();
				groundSoftCheck.PlayerJumped(); //念の為にSoftの方でも2回目のジャンプを防止します。

				_isJumping = true;
			}
			else if (_isGround)
			{
				_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, playerJumpPower);
				groundCheck.PlayerJumped(); //念の為にGroundの方でも2回目のジャンプを防止します。
				groundSoftCheck.PlayerJumped();
				_animator.CrossFade("jump", 0.0f);

				_isJumping = true;
			}
		}

		void UpdateAnimation()
		{
			if (_isJumping)
			{
				_animator.CrossFade("jump", 0.0f);
				if (_isGroundSoft || _isGround)
				{
					_isJumping = false;
				}
			}
			else if (_isMove)
			{
				_animator.CrossFade("walk", 0.0f);
			}
			else
			{
				_animator.CrossFade("wait", 0.0f);
			}
		}
	}
}