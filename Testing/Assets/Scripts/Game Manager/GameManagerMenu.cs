using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
    public void PlayGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public GameObject controlsPanel;

    public void ToggleControlsPanel()
    {
        // Toggle the visibility of the controls panel
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }

    public void BackControl()
    {
        controlsPanel.SetActive(false);
    }
}
