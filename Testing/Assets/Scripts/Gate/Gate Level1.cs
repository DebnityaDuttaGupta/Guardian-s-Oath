using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateLevel1 : MonoBehaviour
{
    public int screenBuildIndex;

    private bool playerEntered = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            playerEntered = true;
        }
        CheckPlayerAndLoadScene(col);
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            playerEntered = false;
        }
    }

    private void CheckPlayerAndLoadScene(Collider col)
    {
        if (playerEntered && col.GetComponent<ProperMovement>().HasKey)
        {
            print("Switching Scene to" + screenBuildIndex);
            SceneManager.LoadScene(screenBuildIndex, LoadSceneMode.Single);
        }
    }
}
