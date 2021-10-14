using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isPause;
    bool endGame;

    public GameObject wonScene;
    public GameObject deathScene;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (!endGame)
        {
            if (isPause)
            {
                Time.timeScale = 0;
            }
            else if (!isPause)
            {
                Time.timeScale = 1;
            }
        }
        else
        {
            Time.timeScale = 0;
        }
        
    }

    public void EndGame(bool win)
    {
        endGame = true;
        if (win)
        {
            wonScene.SetActive(true);
        }
        else
        {
            deathScene.SetActive(true);
        }
    }


    public void PauseGame()
    {
        isPause = !isPause;
    }

    public bool IsGamePause()
    {
        return isPause;
    }
}
