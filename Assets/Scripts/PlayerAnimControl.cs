using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    Animator animator;
    PlayerManager playerManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
    }
    private void Update()
    {
        playerStateProcess();
        
    }
    void playerStateProcess()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.Idle)
        {
            animator.SetBool("isMoving", false);
        }

        if (playerManager.playerState == PlayerManager.PlayerState.Moving)
        {
            animator.SetBool("isMoving", true);
        }
    }
}
