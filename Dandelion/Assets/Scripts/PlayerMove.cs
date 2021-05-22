using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded;
    public Transform groundCheck;

    
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    //for jumping through platforms
    int playerObject, collideObject, fallingEntity, groundObject;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        playerObject = LayerMask.NameToLayer("Player");
        collideObject = LayerMask.NameToLayer("Ground");

    }
    
    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        spriteRenderer.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }



    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (Input.GetButton("Horizontal"))
            Run();
    }
    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps > 0)
        {
            Jump();
            extraJumps--;
        }
        else if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps == 0 && isGrounded)
            Jump();

        if(rigidbody2D.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(playerObject, collideObject, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerObject, collideObject, false);
        }

      
    }
}
