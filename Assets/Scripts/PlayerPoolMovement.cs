using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPoolMovement : MonoBehaviour
{
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float rotateSenstivity = 8f;
    [SerializeField] float movementSpeed = 3f;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject endPoint;

    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameController gameStateController;

    public static bool canMove = true;
    float touchPosX;
    float mouseX;
    Vector3 dirX;

    float timer;
    float delayTime = 0.2f;

    private void Update()
    {
        movementProcess();
    }

    void movementProcess()
    {
        switch(gameStateController.gameState)
        {
            case GameController.GameState.Ready:
                {
                    if(endPoint == null)
                    {
                        endPoint = GameObject.FindGameObjectWithTag("EndPoint"); ;
                        
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        if(EventSystem.current.IsPointerOverGameObject())
                            return;

                        gameStateController.gameState = GameController.GameState.Start;
                    }

                    playerManager.playerState = PlayerManager.PlayerState.Idle;
                    touchPosX = 0;
                    transform.position = spawnPoint.position;
                    break;
                }
            case GameController.GameState.Start:
                {
                    playerMovingStateProcess();
                    break;
                }
            case GameController.GameState.Win:
                {
                    playerWinStateProcess();
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
                    Destroy(endPoint);
                    break;
                }
        }
    }
    void playerMovingStateProcess()
    {
        if (Input.GetMouseButton(0) && !UIManager.isSettingUIOn)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            playerManager.playerState = PlayerManager.PlayerState.Moving;
            runEffect();
            runSound();

            mouseX = Input.GetAxis("Mouse X");
            dirX = new Vector3(mouseX, 0, 0).normalized;

            rotatePlayer(dirX);
            movement();
        }
        else
        {
            playerManager.playerState = PlayerManager.PlayerState.Idle;
        }
    }
    void playerWinStateProcess()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, movementSpeed * Time.deltaTime);
        
        Vector3 dir = endPoint.transform.position - transform.position;
        rotatePlayer(dir);
        
        if (transform.position == endPoint.transform.position)
        {
            playerManager.playerState = PlayerManager.PlayerState.Idle;
            gameStateController.gameState = GameController.GameState.Finish;
        }
    }
    void rotatePlayer(Vector3 dir)
    {
        Quaternion targetRot = Quaternion.LookRotation(dir);

        for (int i = 0; i < playerManager.playerList.Count; i++)
        {
            playerManager.playerList[i].transform.rotation = Quaternion.Lerp(playerManager.playerList[i].transform.rotation,
                                                                            targetRot,
                                                                            rotateSenstivity * Time.deltaTime);
        }
    }
   
    void movement()
    {
        transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
        
        touchPosX += mouseX * sensitivityX * Time.deltaTime;

        touchPosX = Mathf.Clamp(touchPosX, -1.5f, 1.5f);
        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    }

    void runEffect()
    {
        if (timer <= 0)
        {
            FxController.instance.runFx();
            timer = delayTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void runSound()
    {
        if (gameStateController.gameState != GameController.GameState.Lose)
        {
            SoundFxController.instance.runSoundFx();
        }
    }


}
