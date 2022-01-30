using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
	[SerializeField] private GameObject stageClearGameObject;

	[SerializeField] private float stageClearedWaitTime = 3.0f;

	// Goalオブジェクトにステージの番号を付けるのは本当は良くないですが、この仕様にしています。
	[SerializeField] private int currentStageNumber;

	private bool _isStageCleared = false;

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