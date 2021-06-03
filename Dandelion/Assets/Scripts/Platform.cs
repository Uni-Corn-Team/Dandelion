using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool isDeath;

    public Transform deathCheck;
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
