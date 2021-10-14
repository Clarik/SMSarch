using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{
    bool isEscToExit;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
            isEscToExit = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isEscToExit)
                QuitGame();
            else
                GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().PauseGame();
        }
    }

    public void PlayAgain()
    {
        StartCoroutine(PAPlayAgain());
    }

    IEnumerator PAPlayAgain()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
