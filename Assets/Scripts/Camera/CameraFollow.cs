using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameController gameStateController;
    [SerializeField] CinemachineVirtualCamera camObj;

    Cinemachine.CinemachineTransposer camOffset;
    GameObject mainPlayer;
    Vector3 firstCamOffsetPos;
     
    public GameObject getMainPlayer() { return mainPlayer; }

    public Transform getMainPlayerPos()
    {
        return mainPlayer.transform;
    }

    private void Start()
    {
        camOffset = camObj.GetCinemachineComponent<CinemachineTransposer>();
        firstCamOffsetPos = camOffset.m_FollowOffset;
    }

    private void Update()
    {
        if (mainPlayer == null)
        {
            mainPlayer = GameObject.FindGameObjectWithTag("Collected");
        } 
        else
        {
            camObj.Follow = mainPlayer.transform;
        }


        switch (gameStateController.gameState)
        {
            case GameController.GameState.Ready:
                {
                    camOffset.m_FollowOffset = firstCamOffsetPos;

                    //if (mainPlayer == null)
                    //{
                    //    mainPlayer = GameObject.FindGameObjectWithTag("Collected");
                    //}

                    break;
                }
            case GameController.GameState.Start:
                {
                    //if (mainPlayer == null)
                    //{
                    //    mainPlayer = GameObject.FindGameObjectWithTag("Collected");
                    //}

                    break;
                }
            case GameController.GameState.Win:
                {
                    float offsetY = Mathf.Lerp(camOffset.m_FollowOffset.y, 6f, 2 * Time.deltaTime);
                    float offsetZ = Mathf.Lerp(camOffset.m_FollowOffset.z, -8f, 2 * Time.deltaTime);
                    camOffset.m_FollowOffset = new Vector3(camOffset.m_FollowOffset.x, offsetY, offsetZ);

                    break;
                }
            case GameController.GameState.Lose:
                {
                    break;
                }
            case GameController.GameState.Finish:
                {
                    break;
                }
            case GameController.GameState.End:
                {
                    break;
                }
        }

        
    }
}
