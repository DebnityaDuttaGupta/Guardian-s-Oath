using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLevel4 : MonoBehaviour
{
    public static GameManagerLevel4 instance;

    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject pauseMenuUI;
    public GameObject CreditsUI;

    public GameObject playerHealthBar;
    public GameObject bossHealthBar;
    public GameObject levelIndicator;
    public GameObject playericon;
    public GameObject bossicon;

    public float restartDelay = 10f;

    private bool isPaused = false;

    private Animator creditsAnimator;

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
        winPanel.SetActive(false);
        CreditsUI.SetActive(false);

        playerHealthBar.SetActive(true);
        bossHealthBar.SetActive(true);
        levelIndicator.SetActive(true);
        playericon.SetActive(true);
        bossicon.SetActive(true);

        creditsAnimator = CreditsUI.GetComponent<Animator>();
    }

    public void GameEnd()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        StartCoroutine(RestartGame());
    }

    public void GameWin()
    {
        StartCoroutine(DelayBeforeStopTime());
        playerHealthBar.SetActive(false);
        bossHealthBar.SetActive(false);
        levelIndicator.SetActive(false);
        playericon.SetActive(false);
        bossicon.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    IEnumerator DelayBeforeStopTime()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
        winPanel.SetActive(true);
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

    public void CreditScene()
    {
        Time.timeScale = 1f;
        CreditsUI.SetActive(true);

        if (creditsAnimator != null)
        {
            creditsAnimator.Play("Starting Position");
        }
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
