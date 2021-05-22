using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DandelionLib.Strategy;
using DandelionLib.Strategy.GameDifficulty;
using DandelionLib;

public class FallingEntities : MonoBehaviour
{
    public GameObject[] bombs;
    public Transform Zero;
    private List<GameObject> _falingEntitiesQueue;
    private FallingEntityGenerator _fallingEntityGenerator;

    int fallingObject, collideObject;

    // Start is called before the first frame update
    void Start()
    {
        _fallingEntityGenerator = new FallingEntityGenerator(new NormalGame());

        fallingObject = LayerMask.NameToLayer("FallingEntity");
        collideObject = LayerMask.NameToLayer("Ground");
        //making new bomb
        var fe = Instantiate(bombs[0], Zero);
        fe.transform.localPosition = new Vector3(-5, 0, 0);

        _falingEntitiesQueue = new List<GameObject>();
        _falingEntitiesQueue.Add(fe);
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(fallingObject, collideObject, true);
        
        if(_falingEntitiesQueue[_falingEntitiesQueue.Count-1].transform.localPosition.y - Zero.position.y < -2)
        {
            var entity = _fallingEntityGenerator.GetNext();
            int id = (int)new EntityAdapter(entity).Id;
            var fe = Instantiate(bombs[id], Zero);
            Debug.Log(id);
            fe.transform.localPosition = new Vector3(Random.Range(-9,9), Zero.position.y + 2, 0);
            _falingEntitiesQueue.Add(fe);
        }
        if (_falingEntitiesQueue[0].transform.position.y - Zero.position.y < -20)
        {
            var fed = _falingEntitiesQueue[0];
            Destroy(fed);
            _falingEntitiesQueue.RemoveAt(0);
        }


    }
}
