using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGround : MonoBehaviour
{
    GameController gameStateController;
    private void Start()
    {
        gameStateController = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Collected") && gameStateController.gameState == GameController.GameState.Start)
        {
            gameStateController.gameState = GameController.GameState.Win;
        }
    }
}
