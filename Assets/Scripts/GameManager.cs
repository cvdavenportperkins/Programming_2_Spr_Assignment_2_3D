using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance = null;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI youWinText;
    public TextMeshProUGUI gameOverText;
    public float timer;
    private bool isGameOver = false;
    public float gameTime = 120;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
