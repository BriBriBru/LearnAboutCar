using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    [HideInInspector]
    public bool isReady;

    public GameObject rulesPanel;
    public float timeRemaining = 25f;
    public Text displayCountdown;

    private bool _win;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isReady)
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

            if (timeRemaining <= 0f && !_win)
            {
                GameOver();
            }
        }
    }

    public void StartGame()
    {
        isReady = true;
        rulesPanel.SetActive(false);
    }

    private void CheckWin()
    {
        // Check if all toggles are "ison"
    }

    private void GameOver()
    {
        _animator.Play("Game Over");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
