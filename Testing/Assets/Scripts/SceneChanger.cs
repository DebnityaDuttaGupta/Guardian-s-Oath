using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int screenBuildIndex;

    private bool player1Entered = false;
    private bool player2Entered = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player1")
        {
            player1Entered = true;
        }
        else if (col.tag == "Player2")
        {
            player2Entered = true;
        }
        CheckPlayerAndLoadScene();
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player1")
        {
            player1Entered = false;
        }
        else if (col.tag == "Player2")
        {
            player2Entered = false;
        }
    }

    private void CheckPlayerAndLoadScene()
    {
        if(player1Entered && player2Entered)
        {
            print("Switching Scene to" + screenBuildIndex);
            SceneManager.LoadScene(screenBuildIndex, LoadSceneMode.Single);
        }
    }
}
