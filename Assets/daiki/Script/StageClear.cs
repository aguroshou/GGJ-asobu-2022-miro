using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    public void OnClickStageSelectButton()
    {
        SceneManager.LoadScene("GameSelect");
    }

    public void OnClickGameEndButton()
    {
        Application.Quit();
    }
}
