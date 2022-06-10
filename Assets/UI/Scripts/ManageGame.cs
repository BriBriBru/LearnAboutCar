using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    [Header("Countdown")]
    public GameObject rulesPanel;
    public float timeRemaining;
    public Text displayCountdown;

    private Animator _animator;
    private Toggle[] _toggles;
    private bool _isReady = false;
    private bool _lockEnterKey = false;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _toggles = GetComponentsInChildren<Toggle>();
        rulesPanel.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_lockEnterKey)
        {
            StartGame();
            _lockEnterKey = true;
        }

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

            if (CheckWin())
            {
                Win();
            }
        }
    }

    public void StartGame()
    {
        _isReady = true;
        rulesPanel.SetActive(false);
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        _animator.Play("Game Over");
    }

    private void Win()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        _animator.Play("Win");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync("MiniGame");
    }
}