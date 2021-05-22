using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform deathCheck;
    private bool isDeath;
    public LayerMask whatIsPlayer;
    public float checkRadius;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isDeath = Physics2D.OverlapCircle(deathCheck.position, checkRadius, whatIsPlayer);
    }

    private void Update()
    {
        if (isDeath)
        {
            Destroy(player);
        }
    }
}
