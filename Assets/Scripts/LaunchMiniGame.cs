using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchMiniGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("MiniGame");
        }
    }
}
