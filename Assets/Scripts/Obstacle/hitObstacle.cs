using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObstacle : MonoBehaviour
{   
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            FxController.instance.deathFx(this.transform);
            SoundFxController.instance.runDeathSoundFx();

            playerManager.playerList.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    
}
