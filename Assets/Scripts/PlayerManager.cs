using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerState playerState;
    public Transform playerPool;
    public List<GameObject> playerList;
    public enum PlayerState
    {
        Idle,
        Moving,
        Dead
    }
}
