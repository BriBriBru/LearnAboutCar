using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    [Header("Countdown")]
    public GameObject rulesPanel;
    public float timeRemaining = 25f;
    public Text displayCountdown;

    [Header("FPS Controller")]
    public GameObject fpsController;

    public Camera cam;

    private Animator _animator;
    private Toggle[] _toggles;
    private bool _isReady = false;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _toggles = GetComponentsInChildren<Toggle>();
        DisableFpsController();
        rulesPanel.SetActive(true);
    }

    void Update()
    {
        if (_isReady)
        {
            // Decrease the time
            if (timeRemaining >= 0f)
            {
                displayCountdown.text = Mathf.Round(timeRemaining).ToString();
                timeRemaining -= Time.deltaTime;
            }

            // Change text coor to red if there is 5s or less time left
            if (timeRemaining <= 5f)
            {
                displayCountdown.color = Color.red;
            }

            // Launch game over animation if player lose and timeout
            if (timeRemaining <= 0f && !CheckWin())
            {
                GameOver();
            }
        }
    }

    public void StartGame()
    {
        _isReady = true;
        rulesPanel.SetActive(false);
        EnableFpsController();
    }

    private bool CheckWin()
    {   
        foreach (var toggle in _toggles)
        {
            if (!toggle.isOn)
            {
                return false;
            }
        }

        return true;
    }

    private void GameOver()
    {
        //fpsController.SetActive(false);
        _animator.Play("Game Over");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync("MiniGame");
    }

    public void DisableFpsController()
    {
        fpsController.SetActive(false);
        cam.gameObject.SetActive(true);
    }

    public void EnableFpsController()
    {
        fpsController.SetActive(true);
        cam.gameObject.SetActive(false);
    }
}