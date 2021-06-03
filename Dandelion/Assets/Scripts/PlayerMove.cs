using DandelionLib;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 10f;

    public Animator animator;

    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    public Transform groundCheck;

    public DandelionLib.User User;
    
    public float checkRadius;
    public LayerMask whatIsGround;

    public float leftBorder, rightBorder;

    public GameObject player;
    public GameObject healthbar;

    //for jumping through platforms
    int playerObject, collideObject;

    private UserBar UserBar;

    private void Awake()
    {
        Resolution currentResolution = Screen.currentResolution;
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerObject = LayerMask.NameToLayer("Player");
        collideObject = LayerMask.NameToLayer("Ground");

        User = new DandelionLib.User(100, 100);
        leftBorder = -12f * ((float)currentResolution.width / 1920f);
        rightBorder = 12f * ((float)currentResolution.width / 1920f);
    }
    
    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = new Vector3(Mathf.Clamp(Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime).x, leftBorder, rightBorder), transform.position.y, transform.position.z);
        spriteRenderer.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {     
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
            if (UserBar == null)
            {
                UserBar = healthbar.GetComponent<Healthbar>().UserBar;
                User.AddObserver(UserBar);
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
