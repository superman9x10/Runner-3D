using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<level> levelList;

    public int curLevel;
    public bool canLoadLevel;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}

[System.Serializable]
public class level
{
    public string levelName;
    //public int curLevel;
    public List<GameObject> mapModelList;

}
