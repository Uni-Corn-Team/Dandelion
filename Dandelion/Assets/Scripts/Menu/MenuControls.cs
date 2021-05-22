using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void StartPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }

}
