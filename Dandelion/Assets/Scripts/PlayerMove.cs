using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 1f;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    //for jumping through platforms
    int playerObject, collideObject, fallingEntity, groundObject;


    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        playerObject = LayerMask.NameToLayer("Player");
        collideObject = LayerMask.NameToLayer("Collide");
        fallingEntity = LayerMask.NameToLayer("FallingEntities");
        groundObject = LayerMask.NameToLayer("Ground");

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetButtonDown("Jump"))
            Jump();

        if(rigidbody2D.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(playerObject, collideObject, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerObject, collideObject, false);
        }

        Physics2D.IgnoreLayerCollision(fallingEntity, collideObject, true);
        Physics2D.IgnoreLayerCollision(fallingEntity, groundObject, true);
    }
}
