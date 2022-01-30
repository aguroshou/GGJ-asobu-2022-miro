using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageClear1 : MonoBehaviour
{
	public void OnClickStageSelectButton()
	{
		SceneManager.LoadScene("GameSelect");
	}

	public void OnClickNextStageButton()
	{
		SceneManager.LoadScene("Level2");
	}
}
