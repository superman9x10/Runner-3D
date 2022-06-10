using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxController : MonoBehaviour
{

    [SerializeField] PlayerManager playerManager;

    public static FxController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
   
    
    public void runFx ()
    {
        for (int i = 0; i < playerManager.playerList.Count; i++)
        {
            GameObject runFx = ObjectPooling.instance.getObjectFromPool("runFx");
            if (runFx != null)
            {
                runFx.SetActive(true);
                runFx.transform.position = playerManager.playerList[i].transform.position;
                runFx.transform.rotation = playerManager.playerList[i].transform.rotation;
            }

        }
    }

    public void deathFx(Transform playerPos)
    {
        GameObject deadFx = ObjectPooling.instance.getObjectFromPool("deadFx");
        if (deadFx != null)
        {
            deadFx.SetActive(true);
            deadFx.transform.position = playerPos.position;
            deadFx.transform.rotation = playerPos.rotation;
        }
    }

}

