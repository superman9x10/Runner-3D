using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    public List<ObjectToPool> ObjectToPoolList = new List<ObjectToPool>();
    public List<GameObject> Pooling = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        createPooling();
    }

    void createPooling()
    {
        foreach (ObjectToPool obj in ObjectToPoolList)
        {
            for(int i = 0; i < obj.amount; i++)
            {
                GameObject prefab = Instantiate(obj.objPrefab);
                prefab.SetActive(false);
                Pooling.Add(prefab);
            }
        }
    }

    public GameObject getObjectFromPool(string tag)
    {
        for(int i = 0; i < Pooling.Count; i++)
        {
            if(!Pooling[i].activeInHierarchy && Pooling[i].tag == tag)
            {
                return Pooling[i];
            }
        }

        foreach(ObjectToPool obj in ObjectToPoolList)
        {
            if(obj.shouldExpand)
            {
                GameObject prefab = Instantiate(obj.objPrefab);
                prefab.SetActive(false);
                Pooling.Add(prefab);
                return prefab;
            }
        }
        return null;
    }
}


[System.Serializable]
public class ObjectToPool
{
    public string nameObj;
    public int amount;
    public GameObject objPrefab;
    public bool shouldExpand;
}