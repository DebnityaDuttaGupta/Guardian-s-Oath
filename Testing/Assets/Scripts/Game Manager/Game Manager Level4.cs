using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLevel4 : MonoBehaviour
{
    public static GameManagerLevel4 instance;

    public GameObject gameOverPanel;
    public GameObject pauseMenuUI;

    public Text gameOverText;

    public float restartDelay = 10f;

    private bool isPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void GameEnd()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        gameOverText.text = "You Died";
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(restartDelay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(8);
        Time.timeScale = 1f;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
