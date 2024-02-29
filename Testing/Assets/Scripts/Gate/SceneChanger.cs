using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int screenBuildIndex;

    private bool playerEntered = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            playerEntered = true;
        }
        CheckPlayerAndLoadScene();
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            playerEntered = false;
        }
    }

    private void CheckPlayerAndLoadScene()
    {
        if(playerEntered)
        {
            print("Switching Scene to" + screenBuildIndex);
            SceneManager.LoadScene(screenBuildIndex, LoadSceneMode.Single);
        }
    }
}
