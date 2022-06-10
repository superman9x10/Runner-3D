using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] Text levelText;

    [SerializeField] GameObject winUI;
    [SerializeField] GameObject readyUI;
    [SerializeField] GameObject inGameUI;
    [SerializeField] GameObject loseUI;

    [SerializeField] GameObject settingUI;

    public static bool isSettingUIOn;
    private void Update()
    {
        checkSettingUI();
        checkGameState();
    }

    void checkGameState()
    {
        switch (gameController.gameState)
        {
            case GameController.GameState.Ready:
                {
                    levelText.text = "Level. " + (LevelManager.instance.curLevel + 1).ToString();
                    inGameUI.SetActive(true);
                    readyUI.SetActive(true);
                    winUI.SetActive(false);
                    loseUI.SetActive(false);
                    break;
                }
            case GameController.GameState.Start:
                {
                    readyUI.SetActive(false);
                    break;
                }
            case GameController.GameState.Win:
                {
                    break;
                }
            case GameController.GameState.Lose:
                {
                    loseUI.SetActive(true);
                    break;
                }
            case GameController.GameState.Finish:
                {
                    inGameUI.SetActive(false);
                    winUI.SetActive(true);
                    break;
                }
            case GameController.GameState.End:
                {
                    break;
                }
        }
    }

    void checkSettingUI()
    {
        if(!settingUI.activeInHierarchy)
        {
            isSettingUIOn = false;
        } else
        {
            isSettingUIOn = true;
        }
    }
    public void loadLevel()
    {
        gameController.gameState = GameController.GameState.End;
    }

    public void rePlay()
    {
        LevelManager.instance.canLoadLevel = true;
    }

    public void UISettingControl()
    {
        if(!settingUI.activeInHierarchy)
        {
            
            settingUI.SetActive(true);
        } else
        {
            settingUI.SetActive(false);
        }
    }
}
