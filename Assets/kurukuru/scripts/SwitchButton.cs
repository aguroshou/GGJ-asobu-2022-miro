using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
	[SerializeField] private GameObject hitCheck;

	// 箱の下の方にある当たり判定です。
	private BoxCollider2D _hitCheckBoxCollider2D;

	private BoxCollider2D _playerBoxCollider2D;

	// Start is called before the first frame update
	void Start()
	{
		_hitCheckBoxCollider2D = hitCheck.GetComponent<BoxCollider2D>();
		_playerBoxCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (_hitCheckBoxCollider2D.IsTouching(_playerBoxCollider2D)
		&& other.gameObject.CompareTag("Player"))
		{
			var manager = FindObjectOfType<GimmickManager>();
			manager.AllChange();
		}
	}
}
