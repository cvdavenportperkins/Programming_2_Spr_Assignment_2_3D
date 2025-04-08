using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Vector3 spawnPosition;
    public TextMeshProUGUI countdownText;
    public bool hasSpawned = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasSpawned)
        {
            hasSpawned = true;
            StartCoroutine(SpawnWithCountdown());
        }           
    }

    IEnumerator SpawnWithCountdown()
    {
        playerRigidbody.position = spawnPosition;  //set initial player position
        playerRigidbody.angularVelocity = Vector3.zero;
        playerRigidbody.linearVelocity = Vector3.zero;
        playerRigidbody.isKinematic = true;

        for (int i = 3; i > 0; i--)  //countdown
        {
            countdownText.text = i.ToString();  //Update countdown text
            yield return new WaitForSeconds(1f);  //Wait for 1 second
        }

        countdownText.text = "GO!"; //enable movement after countdown
        yield return new WaitForSeconds(1f);
        countdownText.text = ""; //clear countdown text

        playerRigidbody.isKinematic = false; //Re-enable physics
    }

   
}
