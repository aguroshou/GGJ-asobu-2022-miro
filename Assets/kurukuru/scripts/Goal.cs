using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

	[SerializeField]
	private SpriteRenderer _spriteRenderer;
	private float _time;
	private int _spriteCount;
	[SerializeField] private float animationInterval = 0.4f;
	[SerializeField] private List<Sprite> spriteList = new List<Sprite>();

	[SerializeField] private GameObject stageClearGameObject;

	[SerializeField] private float stageClearedWaitTime = 3.0f;

	// Goalオブジェクトにステージの番号を付けるのは本当は良くないですが、この仕様にしています。
	[SerializeField] private int currentStageNumber;

	private bool _isStageCleared = false;


	private void Update()
	{
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("ステージ" + currentStageNumber + "をクリアしました。");
			PlayerPrefs.SetInt("STAGE" + currentStageNumber.ToString(), 1);
			PlayerPrefs.Save();

			if (!_isStageCleared)
			{
				_isStageCleared = true;
				FindObjectOfType<GameManager>().Clear();
			}
		}
	}
}