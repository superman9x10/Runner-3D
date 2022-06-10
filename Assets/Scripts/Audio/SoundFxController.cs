using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxController : MonoBehaviour
{
    [SerializeField] AudioClip run;
    [SerializeField] AudioClip death;
    [SerializeField] AudioSource audio;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameController gameStateController;

    public static SoundFxController instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    float timer;
    [SerializeField] float runSoundFxelay;

    public void runSoundFx()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.Moving)
        {
            if (timer <= 0)
            {
                audio.PlayOneShot(run);
                timer = runSoundFxelay;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    public void runDeathSoundFx()
    {
        audio.PlayOneShot(death);
    }
}
