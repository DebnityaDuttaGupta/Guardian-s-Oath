using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerEscapeMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject loseScreenUI;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        loseScreenUI.SetActive(false);
        FindAnyObjectByType<AudioManager>().Play("Background");
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

        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            PlayerDefeated();
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
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void PlayerDefeated()
    {
        loseScreenUI.SetActive(true);
        StartCoroutine(RestartLevelAfterDelay(10f));
    }

    IEnumerator RestartLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
