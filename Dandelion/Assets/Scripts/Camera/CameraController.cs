using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    private bool isLeft;
    private Transform player;
    private int lastX;
    public GameObject CanvasPause;
    public GameObject CanvasPauseMobile;
    public bool IsPaused = false;

    public GameObject bar;
    public GameObject pause;

    //limits
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float upperLimit;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        Time.timeScale = 1;
        IsPaused = false;
        FindPlayer(isLeft);

#if UNITY_STANDALONE
        var resolution = Screen.currentResolution;
        bar.transform.localScale = new Vector3(5f, 5f, 3f);
        bar.transform.localPosition = new Vector3(
            (float)(-0.35 * resolution.width),
            (float)(0.35 * resolution.height),
            bar.transform.localPosition.z);
#endif

#if UNITY_ANDROID || UNITY_IOS
        var resolution = Screen.currentResolution;
        pause.SetActive(true);
        bar.transform.localScale = new Vector3(5f, 5f, 3f);
        bar.transform.localPosition = new Vector3(
            (float)(-0.35 * resolution.width),
            (float)(0.35 * resolution.height),
            bar.transform.localPosition.z);
        pause.transform.localPosition = new Vector3(
            (float)(0.45 * resolution.width),
            (float)(0.4 * resolution.height),
            bar.transform.localPosition.z);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                IsPaused = false;
                CanvasPause.GetComponent<PauseMenuControls>().BackPressed();
            }
            else
            {
                CanvasPause.SetActive(true);
                Time.timeScale = 0;
                IsPaused = true;
            }
        }
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if(isLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            transform.position.y,// Mathf.Clamp(transform.position.x, bottomLimit, upperLimit),
            transform.position.z);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if(playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    public void SetPause()
    {
#if UNITY_STANDALONE
        CanvasPause.SetActive(true);
#endif
#if UNITY_ANDROID || UNITY_IOS
        CanvasPauseMobile.SetActive(true);
#endif
        Time.timeScale = 0;
        IsPaused = true;
    }
}
