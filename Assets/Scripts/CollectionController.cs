using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
    PlayerManager playerManager;
    GameController gameStateController;
    bool isOnGround;


    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        gameStateController = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameController>();

        playerManager.playerList.Add(gameObject);
    }

    private void Update()
    {
        switch(gameStateController.gameState)
        {
            case GameController.GameState.Ready:
                {
                    
                    break;
                }
            case GameController.GameState.Start:
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 2 * Time.deltaTime);
                    limitedMoving();
                    break;
                }
            case GameController.GameState.Finish:
                {
                    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-Vector3.forward), 3 * Time.deltaTime);
                    break;
                }
            case GameController.GameState.Win:
                {
                    break;
                }
            case GameController.GameState.Lose:
                {
                    break;
                }
            case GameController.GameState.End:
                {
                    break;
                }
        }
    }

    void limitedMoving()
    {
        Vector3 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, -1.5f, 1.5f);
        transform.position = temp;
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            if (!playerManager.playerList.Contains(collision.gameObject))
            {
                collision.gameObject.transform.parent = playerManager.playerPool;
                collision.gameObject.tag = "Collected";
                collision.gameObject.AddComponent<hitObstacle>();
                collision.gameObject.AddComponent<CollectionController>();
                collision.gameObject.GetComponent<PlayerAnimControl>().enabled = true;
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
            
        }

        if(collision.gameObject.CompareTag("Ground") && !isOnGround)
        {
            isOnGround = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    
}
