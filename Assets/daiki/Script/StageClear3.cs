using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageClear3 : MonoBehaviour
{
    public void OnClickStageSelectButton()
    {
        SceneManager.LoadScene("GameSelect");
    }
}
