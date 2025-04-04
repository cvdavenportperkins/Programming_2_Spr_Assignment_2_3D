using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public static PlayerCollision instance;
    public GameManager gameManager;


    void Awake()
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

        if (gameManager == null)
        {
            gameManager = Object.FindFirstObjectByType<GameManager>();
            Debug.LogError("GameManager is not assigned!");
            return;

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("GameManager is " + (gameManager != null ? "assigned" : "null"));

        if (collision.CompareTag("Checkpoint"))
        {
            gameManager.CollectCheckpoint(collision.gameObject);
            Destroy(collision.gameObject);
            gameManager.AddScore(100); // Add points for each Checkpoint
            SoundManager.instance.PlaySound(SoundManager.instance.CheckpointSFX); // Play sound effect
        }

    }
}
