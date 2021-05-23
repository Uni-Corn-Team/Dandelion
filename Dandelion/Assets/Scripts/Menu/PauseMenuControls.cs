using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


class PauseMenuControls : MonoBehaviour
{
    public GameObject PauseCanvas;
    public void BackPressed()
    {
        Time.timeScale = 1;
        PauseCanvas.SetActive(false);
    }

    public void GoToMenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}

