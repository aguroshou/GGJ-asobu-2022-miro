using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using UnityEngine;

[Serializable]
public class Change
{
	[Description("変化元")]
	public GimmickID Prev;
	[Description("変化後")]
	public GimmickID Next;
}


public class SwitchButton : MonoBehaviour
{
	[Description("変化するスイッチリスト")]
	[SerializeField]
	List<Change> _ChangeList = new List<Change>()
	{
		new Change(){ Prev = GimmickID.Ame, Next = GimmickID.Gumi},
		new Change(){ Prev = GimmickID.Gumi, Next = GimmickID.Cookie},
		new Change(){ Prev = GimmickID.Cookie, Next = GimmickID.Ame},
	};

	[SerializeField] private GameObject hitCheck;
	// 箱の下の方にある当たり判定です。
	private BoxCollider2D _hitCheckBoxCollider2D;

	private CapsuleCollider2D _playerCapsuleCollider2D;

	// Start is called before the first frame update
	void Start()
	{
		_hitCheckBoxCollider2D = hitCheck.GetComponent<BoxCollider2D>();
		_playerCapsuleCollider2D = GameObject.Find("Player").GetComponent<CapsuleCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (_hitCheckBoxCollider2D.IsTouching(_playerCapsuleCollider2D)
		&& other.gameObject.CompareTag("Player"))
		{
			var manager = FindObjectOfType<GimmickManager>();
			manager.AllChange(_ChangeList);
		}
	}
}
