using DandelionLib;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 10f;

    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private UserBar userBar;

    public Animator animator;
    public Transform groundCheck;
    public User user;
    
    public float checkRadius;
    public LayerMask whatIsGround;

    public float leftBorder;
    public float rightBorder;

    public GameObject player;
    public GameObject healthbar;

    //for jumping through platforms
    int playerObject;
    int collideObject;

    private AudioSource audio;

    private void Awake()
    {
        Resolution currentResolution = Screen.currentResolution;
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerObject = LayerMask.NameToLayer("Player");
        collideObject = LayerMask.NameToLayer("Ground");

        user = new DandelionLib.User(100, 100);

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom-left corner
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // top-right corner

        leftBorder = min.x;
        rightBorder = max.x;
        print(min.x);
        print(max.x);

        audio = GetComponent<AudioSource>();
    }
    
    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = new Vector3(Mathf.Clamp(Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime).x, leftBorder, rightBorder), transform.position.y, transform.position.z);
        spriteRenderer.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
         audio.Play();
         rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        if (!animator.GetBool("IsDead"))
        {
            if (Input.GetButton("Horizontal"))
            {
                animator.SetFloat("Speed", 1);
                Run();
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("IsDead"))
        {
            if (userBar == null)
            {
                userBar = healthbar.GetComponent<Healthbar>().UserBar;
                user.AddObserver(userBar);
            }

            if (rigidbody2D.velocity.y == 0 && Input.GetButton("Vertical"))
            {
                Jump();
            }

            if (rigidbody2D.velocity.y == 0)
            {
                animator.SetBool("IsJump", false);
            }
            else
            {
                animator.SetBool("IsJump", true);
            }

            if (rigidbody2D.velocity.y > 0)
            {
                Physics2D.IgnoreLayerCollision(playerObject, collideObject, true);
            }
            else
            {
                Physics2D.IgnoreLayerCollision(playerObject, collideObject, false);
            }
        }
    }
}
