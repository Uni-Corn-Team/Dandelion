using Assets.DandelionLib.Data;
using Assets.DandelionLib.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    public Text bestScore;

    public void Awake()
    {
        score.text = $"Score: {Healthbar.maxhight}";
        DifficultyType type = SettingsMenu.currentDiffucultyType;
        string difficulty = type.ToString().TrimEnd('e').TrimEnd('m').TrimEnd('a').TrimEnd('G').ToLower();
        RecordTable.ReplaceRecordInTable(new Record { Score = Healthbar.maxhight, Type = type });
        bestScore.text = $"Best at {difficulty}: {RecordTable.GetRecordByDifficultyType(type).Score}";
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