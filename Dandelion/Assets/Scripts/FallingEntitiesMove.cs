using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEntitiesMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rigidbody2D;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * Time.deltaTime);
       // rigidbody2D.velocity = (target.transform.position - transform.position).normalized * speed;
    }
}
