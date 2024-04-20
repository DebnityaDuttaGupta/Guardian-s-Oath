using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public FirststCameraLevel4 firstCameraScript;
    public SimpleCamera simpleCameraScript;
    public BossHealth2 bossHealthScript;

    void Start()
    {
        // Disable the simple camera script initially
        simpleCameraScript.enabled = false;

        // Subscribe to the boss destroyed event
        bossHealthScript.OnBossDestroyed += OnBossDestroyed;
    }

    void OnBossDestroyed()
    {
        // Enable the simple camera script and disable the first camera script
        simpleCameraScript.enabled = true;
        firstCameraScript.enabled = false;
    }
}
