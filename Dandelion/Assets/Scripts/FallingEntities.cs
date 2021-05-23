using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DandelionLib.Strategy;
using DandelionLib.Strategy.GameDifficulty;
using DandelionLib;
using DandelionLib.Entities;

public class FallingEntities : MonoBehaviour
{
    public GameObject[] bombs;
    public Transform Zero;
    private List<GameObject> _falingEntitiesQueue;
    private FallingEntityGenerator _fallingEntityGenerator;
    public GameObject player;

    private List<IEntity> entities;

    int fallingObject, collideObject;


    //for collide bombs
    public LayerMask whatIsPlayer;
    private bool isTriggered;
    public float checkRadius;

    // Start is called before the first frame update
    void Start()
    {
        entities = new List<IEntity>();
        _fallingEntityGenerator = new FallingEntityGenerator(new NormalGame());

        fallingObject = LayerMask.NameToLayer("FallingEntity");
        collideObject = LayerMask.NameToLayer("Ground");
        //making new bomb
        var fe = Instantiate(bombs[0], Zero);
        fe.transform.localPosition = new Vector3(-5, 0, 0);

        Debug.Log(player.GetComponent<PlayerMove>().User.CureentHealth);

        _falingEntitiesQueue = new List<GameObject>();
        _falingEntitiesQueue.Add(fe);



    }

    // Update is called once per frame
    void Update()
    {
        GameObject Removef = null;
        int index = -1;
        foreach (var item in _falingEntitiesQueue)
        {
            if (Mathf.Abs(player.transform.position.x - item.transform.position.x) < 0.5f && Mathf.Abs(player.transform.position.y - item.transform.position.y) < 1.23f)
            {
                
                Removef = item;
                index = _falingEntitiesQueue.IndexOf(item);
                entities[index].Colide(player.GetComponent<PlayerMove>().User);
                Debug.Log(player.GetComponent<PlayerMove>().User.CureentHealth);
                break;             
            }            
        }
        if(Removef != null)
        {
            entities.RemoveAt(index);
            _falingEntitiesQueue.Remove(Removef);
            Destroy(Removef);
        }




        Physics2D.IgnoreLayerCollision(fallingObject, collideObject, true);

        if(_falingEntitiesQueue[_falingEntitiesQueue.Count-1].transform.localPosition.y - Zero.position.y < -2)
        {
            var entity = _fallingEntityGenerator.GetNext();
            int id = (int)new EntityAdapter(entity).Id;
            var fe = Instantiate(bombs[id], Zero);
            fe.transform.localPosition = new Vector3(Random.Range(-9,9), Zero.position.y + 2, 0);
            _falingEntitiesQueue.Add(fe);
            entities.Add(entity);
        }
        if (_falingEntitiesQueue[0].transform.position.y - Zero.position.y < -20)
        {
            var fed = _falingEntitiesQueue[0];
            Destroy(fed);
            _falingEntitiesQueue.RemoveAt(0);
        }


    }
}
