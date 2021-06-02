using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;

    public void Awake()
    {
        score.text = $"Score: {Healthbar.maxhight}";
    }

    public void NewGamePressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    public void MenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}