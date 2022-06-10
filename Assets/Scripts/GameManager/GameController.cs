using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform spawnPoint;
    
    bool isEndGame;
    int curLevel;
    public GameState gameState;
    public enum GameState
    {
        Ready,
        Start,
        Win,
        Lose,
        Finish,
        End
    }

    private void Start()
    {
        gameState = GameState.Ready;
    }
    private void Update()
    {
        switch(gameState)
        {
            case GameState.Ready:
                {
                    isEndGame = false;
                    if (playerManager.playerList.Count == 0)
                    {
                        GameObject player = Instantiate(playerPrefab, spawnPoint.transform);
                        player.transform.parent = spawnPoint.transform;
                    }
                    break;
                }
                case GameState.Start:
                {
                    if (playerManager.playerList.Count == 0)
                    {
                        gameState = GameState.Lose;
                    }
                    break;
                }
            case GameState.Finish:
                {
                    break;
                }
            case GameState.Win:
                {
                    break;
                }
            case GameState.Lose:
                {
                    break;
                }
            case GameState.End:
                {
                    if(!isEndGame)
                    {
                        isEndGame = true;
                        StartCoroutine("nextLevel");
                    }
                    break;
                }
        }
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(0f);

        if(LevelManager.instance.curLevel < LevelManager.instance.levelList.Count - 1)
        {
            LevelManager.instance.curLevel++;
            //curLevel = LevelManager.instance.curLevel;
        } else
        {
            LevelManager.instance.curLevel = 0;
        }

        LevelManager.instance.canLoadLevel = true;
        
    }

}
