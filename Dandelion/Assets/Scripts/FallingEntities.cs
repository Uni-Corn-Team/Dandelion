using System.Collections.Generic;
using UnityEngine;
using DandelionLib.Strategy;
using DandelionLib.Strategy.GameDifficulty;
using DandelionLib;
using Assets.DandelionLib.Enums;
using Assets.DandelionLib.Enums.EnumsConverters;

public class FallingEntities : MonoBehaviour
{
    public GameObject[] bombs;
    public Transform Zero;
    
    private FallingEntityGenerator _fallingEntityGenerator;
    public GameObject player;

    private List<IUnityEntityObject> entities;
    public List<GameObject> _falingEntitiesGameObjects;

    int fallingObject, collideObject, playerObject;

    //for collide bombs
    public LayerMask whatIsPlayer;
    private bool isTriggered;
    public float checkRadius;

    // Start is called before the first frame update
    void Start()
    {
        entities = new List<IUnityEntityObject>();

        IGameDifficulty gameDifficulty;
        DifficultyType type = SettingsMenu.currentDiffucultyType;

        gameDifficulty = DifficultyTypeConverter.ToIGameDifficulty(type);

        _fallingEntityGenerator = new FallingEntityGenerator(gameDifficulty);

        fallingObject = LayerMask.NameToLayer("FallingEntity");
        collideObject = LayerMask.NameToLayer("Ground");
        playerObject = LayerMask.NameToLayer("Player");
        //making new bomb
        //var entity = _fallingEntityGenerator.GetNext();
        var iUnityEntity = new EntityAdapter(_fallingEntityGenerator.GetNext());
        int id = (int)iUnityEntity.Id;
        var fe = Instantiate(bombs[id], Zero.position, Zero.rotation);
        fe.transform.localPosition = new Vector3(-15, 0, 0);             
        _falingEntitiesGameObjects = new List<GameObject>();
        _falingEntitiesGameObjects.Add(fe);
        entities.Add(iUnityEntity);

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Removef = null;
        int index = -1;
        foreach (var item in _falingEntitiesGameObjects)
        {
            if (Mathf.Abs(player.transform.position.x - item.transform.position.x) < 1f
                && Mathf.Abs(player.transform.position.y - item.transform.position.y) < 1.23f)
            {
                Removef = item;
                index = _falingEntitiesGameObjects.IndexOf(item);
            
                entities[index].Colide(player.GetComponent<PlayerMove>().user);
               
                break;             
            }            
        }
        if(Removef != null)
        {
            entities.RemoveAt(index);
            _falingEntitiesGameObjects.Remove(Removef);
            
            Destroy(Removef);
        }

        Physics2D.IgnoreLayerCollision(fallingObject, collideObject, true);
        Physics2D.IgnoreLayerCollision(fallingObject, playerObject, true);

        if (_falingEntitiesGameObjects[_falingEntitiesGameObjects.Count-1]
            .transform.localPosition.y - Zero.position.y < -2)
        {
            var iUnityEntity = new EntityAdapter(_fallingEntityGenerator.GetNext());
            int id = (int)iUnityEntity.Id;
            var fe = Instantiate(bombs[id], Zero.position, Zero.rotation);
         
            fe.transform.localPosition = new Vector3(Random.Range(-9,9), Zero.position.y + 2, 0);
            _falingEntitiesGameObjects.Add(fe);
          
            entities.Add(iUnityEntity);
        }
        if (_falingEntitiesGameObjects[0].transform.position.y - Zero.position.y < -20)
        {
            var fed = _falingEntitiesGameObjects[0];
            Destroy(fed);
            _falingEntitiesGameObjects.RemoveAt(0);
            entities.RemoveAt(0);
        }
    }
}
