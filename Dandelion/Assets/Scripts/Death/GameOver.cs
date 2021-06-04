using Assets.DandelionLib.Data;
using Assets.DandelionLib.Enums;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
#if UNITY_STANDALONE
    public GameObject bestScoreCanvas;
#endif
    public Text bestScore;

    public void Awake()
    {
        score.text = $"Score: {Healthbar.maxhight}";
#if UNITY_STANDALONE
        bestScoreCanvas.SetActive(false);
        DifficultyType type = SettingsMenu.currentDiffucultyType;
        string difficulty = type.ToString().TrimEnd('e').TrimEnd('m').TrimEnd('a').TrimEnd('G').ToLower();
        Debug.Log(RecordTable.ReplaceRecordInBest(new Record { Score = Healthbar.maxhight, Type = type }));
        bestScore.text = $"Best at {difficulty}: {RecordTable.GetBestRecordByType(type).Score}";
#endif
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