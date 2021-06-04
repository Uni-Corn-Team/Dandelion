using Assets.DandelionLib.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void StartPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Awake()
    {
#if UNITY_ANDROID || UNITY_IOS
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
#endif
    }

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
        //RecordTable.SerializeBestRecords();
    }

}
