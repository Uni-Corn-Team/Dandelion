using UnityEngine;

public class BG : MonoBehaviour
{
    public float speed;
    private Transform m_Transform;
    private float m_Size;
    private float m_pos;
    public GameObject player;
    public new GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Size = GetComponent<SpriteRenderer>().bounds.size.y;
        player = GameObject.Find("Player");
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > camera.transform.position.y)
            Moves();  
    }


    private void Moves()
    {
        m_pos += speed * Time.deltaTime;
        m_pos = Mathf.Repeat(m_pos, m_Size);
        m_Transform.position = new Vector3(0, m_pos, 0);
    }
}
