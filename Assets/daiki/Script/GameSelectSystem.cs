using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelectSystem : MonoBehaviour
{

    public void OnClickLevel1Button()
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void OnClickLevel2Button()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void OnClickLevel3Button()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void OnClicGameEndButton()
    {
        Application.Quit();
    }
}
