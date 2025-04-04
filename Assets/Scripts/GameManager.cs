using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI youWinText;
    public TextMeshProUGUI gameOverText;
    public int score = 0;
    public float timer;
    private bool isGameOver;
    public float gameTime = 120;

    public Transform indicator;
    public Transform checkpoint;
    public List<GameObject> checkpoints = new List<GameObject>();

    private void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            instance = this; // Set instance to this
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }

        // Make GameManager persistent across scenes
        DontDestroyOnLoad(gameObject);


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameOver = false;
        timer = gameTime;
        score = 0;
        UpdateScore();
        UpdateTimer();
        gameOverText.gameObject.SetActive(false);
        youWinText.gameObject.SetActive(false);

        GameObject[] checkpointsArray = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkpoints.AddRange(checkpointsArray);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime;
            UpdateTimer();

            if (timer <= 0)
            {
                timer = 0;
                GameOver();
            }
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
        CheckVictoryCondition();
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("Scoretext is null!");
        }
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.FloorToInt(timer);
        }
        else
        {
            Debug.LogError("Timertext is null!");
        }
    }

    public void GameOver()
    {

        isGameOver = true;
        // Show game over UI or reload the scene
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        Debug.Log("Game Over!");
        StartCoroutine(RestartGameAfterDelay());
    }

    public void Victory()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            // show you win UI or reload the scene
            if (youWinText != null)
            {
                youWinText.gameObject.SetActive(true);
            }

            Debug.Log("Victory");
            StartCoroutine(RestartGameAfterDelay());
        }
    }

    private IEnumerator RestartGameAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        RestartGame();
    }

    private void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        timer = 0;
        isGameOver = false;
        score = 0;

        UpdateScore();
        UpdateTimer();

        checkpoints.Clear();
        GameObject[] checkpointsArray = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkpoints.AddRange(checkpointsArray);
    }

    private void CheckVictoryCondition()
    {
        if (checkpoints.Count == 0)
        {
            Victory();
        }
    }

    public void CollectCheckpoint(GameObject checkpoint)
    {
        checkpoints.Remove(checkpoint);
    }
}
