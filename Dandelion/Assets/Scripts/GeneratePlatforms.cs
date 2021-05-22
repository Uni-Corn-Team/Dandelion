using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    public GameObject[] SmallPlatforms;
    public GameObject Camera;
    public Transform Zero;

    private Vector3 _lastUpdateCameraPosition;
    private Vector3 _lastZeroPosition;
    private float _deathline;
    private const float _birthline = -4;
    private Queue<GameObject> _platforms;

    // Start is called before the first frame update
    void Start()
    {
        _platforms = new Queue<GameObject>();
        _lastUpdateCameraPosition = Camera.transform.position;
        _lastZeroPosition = Zero.position;
        for (int j = 0; j < 8; j++)
        {
            GeneratePlatformes();
        }
        _lastUpdateCameraPosition.y = _lastZeroPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.transform.position.y - _lastUpdateCameraPosition.y > _birthline)
        {
            _lastUpdateCameraPosition = Camera.transform.position;
            GeneratePlatformes();
        }
        while(_platforms.Peek().transform.position.y < _deathline)
        {
            var cell = _platforms.Dequeue();
            Destroy(cell);
        }
    }

    public void Generate(float x, float y)
    {
        var rand = Random.Range(0, SmallPlatforms.Length);
        var cell = Instantiate(SmallPlatforms[rand], Zero);
        cell.transform.localPosition = new Vector3(x, y, 0);
        _platforms.Enqueue(cell);
    }

    private void GeneratePlatformes()
    {
        for (int k = 0; k < Random.Range(1, 3); k++)
        {
            int num = 8;
            float i = _lastZeroPosition.x + Random.Range(-num, num);
            _lastZeroPosition.x = (i < -num) ? i + num : (i > num) ? i - num : i;
            Generate(i, _lastZeroPosition.y + Random.Range(-1, 1));
        }
        _lastZeroPosition.y += Random.Range(2, 3);
        _deathline = _lastUpdateCameraPosition.y - 20;
    }
}
