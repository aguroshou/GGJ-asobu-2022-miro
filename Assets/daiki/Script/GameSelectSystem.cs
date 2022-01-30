using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelectSystem : MonoBehaviour
{

	public void OnClickLevel1Button()
	{
		SceneManager.LoadScene("Level1");
	}

	public void OnClickLevel2Button()
	{
		SceneManager.LoadScene("Level2");
	}

	public void OnClickLevel3Button()
	{
		SceneManager.LoadScene("Level3");
	}

	public void OnClicGameEndButton()
	{
		Application.Quit();
	}
}
