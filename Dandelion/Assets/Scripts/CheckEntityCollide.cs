using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEntityCollide : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    private bool isTriggered;
    public Transform playerCheck;
    public float checkRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        isTriggered = Physics2D.OverlapCircle(playerCheck.position, checkRadius, whatIsPlayer);
    }
    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
            Debug.Log("YYyy");
    }
}
