using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] Transform parentPos;
    [SerializeField] GameController gameStateController;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] bool canCreate;
    [SerializeField] List<GameObject> mapModels;
    
    GameObject ground;

    private void Start()
    {
        firstCreateMap();
    }

    private void Update()
    {
        if(LevelManager.instance.canLoadLevel)
        {
            LevelManager.instance.canLoadLevel = false;
            StartCoroutine("createMap");
        }
    }

    void firstCreateMap()
    {
        if (canCreate)
        {
            for (int i = 0; i < LevelManager.instance.levelList[0].mapModelList.Count; i++)
            {
                ground = Instantiate(LevelManager.instance.levelList[0].mapModelList[i], new Vector3(0, 0, 10) * i, Quaternion.identity);
                mapModels.Add(ground);
                ground.transform.parent = parentPos.transform;
            }
        }
    }
    IEnumerator createMap()
    {
        yield return new WaitForSeconds(0f);
        mapGenarate();
        resetPlayer();
        
        gameStateController.gameState = GameController.GameState.Ready;
    }

    void mapGenarate()
    {
        int curLevel = LevelManager.instance.curLevel;

        for (int i = 0; i < mapModels.Count; i++)
        {
            Destroy(mapModels[i]);
        }

        mapModels.Clear();

        for (int i = 0; i < LevelManager.instance.levelList[curLevel].mapModelList.Count; i++)
        {
            ground = Instantiate(LevelManager.instance.levelList[curLevel].mapModelList[i], new Vector3(0, 0, 10) * i, Quaternion.identity);
            mapModels.Add(ground);
            ground.transform.parent = parentPos.transform;
        }
    }
    void resetPlayer()
    {
        for(int i = 0; i < playerManager.playerList.Count; i++)
        {
            Destroy(playerManager.playerList[i]);
        }
        playerManager.playerList.Clear();   
    }
}

