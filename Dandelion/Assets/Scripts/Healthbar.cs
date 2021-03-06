using DandelionLib;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image Bar;
    public Image ShadowBar;
    public Text TextBar;
    public float Fill;
    public UserBar UserBar;
    public Text HightText;
    public Image HeartImg;
    public GameObject hight;
    public GameObject playerMove;

    private Color liteRed;
    private Color liteYellow;
    private Color liteGreen;

    public static int maxhight;

    // Start is called before the first frame update
    void Start()
    {
        UserBar = new UserBar();
        Fill = 1f;

        liteRed = new Color(238/255.0f, 156/255.0f, 156/ 255.0f);
        liteYellow = new Color(238/ 255.0f, 203/ 255.0f, 156/ 255.0f);
        liteGreen = new Color(156/ 255.0f, 238/ 255.0f, 167/ 255.0f);

        maxhight = 0;
        HightText.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        Fill = UserBar.HealthBarPercents;
        Bar.fillAmount = Fill;
        if(Bar.fillAmount <= 0.7f)
        {
            if(Bar.fillAmount <= 0.30f)
            {
                Bar.color = Color.red;
                TextBar.color = Color.red;
                HeartImg.color = Color.red;
                ShadowBar.color = liteRed;
            }
            else
            {
                Bar.color = Color.yellow;
                TextBar.color = Color.yellow;
                HeartImg.color = Color.yellow;
                ShadowBar.color = liteYellow;
            }

        }
        else
        {
            Bar.color = Color.green;
            TextBar.color = Color.green;
            HeartImg.color = Color.green;
            ShadowBar.color = liteGreen;
        }
        TextBar.text = $"{UserBar.HealthBar} ?? {UserBar.MaxHealth}";

        int _hight = (int)hight.GetComponent<GeneratePlatforms>().Camera.transform.position.y;
        maxhight = maxhight < _hight ? _hight : maxhight;
        HightText.text = $"Hight {_hight}/{maxhight}";

        if(Fill == 0)
        {
            playerMove.GetComponent<PlayerMove>().animator.SetBool("IsDead", true);
            StartCoroutine(WaiterDeath());
        }
    }

    IEnumerator WaiterDeath()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Death");
    }
}
