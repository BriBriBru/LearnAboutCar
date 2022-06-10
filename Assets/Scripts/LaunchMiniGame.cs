using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchMiniGame : MonoBehaviour
{
    void Update()
    {
        // If we are in the main scene
        // We have to press g key to launch the mini game
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("MiniGame");
        }
    }
}
