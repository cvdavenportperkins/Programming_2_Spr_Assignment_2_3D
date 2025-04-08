using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CustomCustomPlayerInputManager : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 moveInput = Vector3.zero;
    public Transform playerMove;
    
    public float speedMultiplier = 0.05f; //base speed multiplier
    public float forceMultiplier = 0.10f; //base force multiplier
    public float maxVelocity = 40f; //max velocity
    public float baseAcceleration = 0.10f; //initial acceleration rate
    public float accelerationScale = 0.02f; //acceleration increase per second
    private float accelerationTimer = 0f; //timer to scale acceleration over time

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMove = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        if (moveInput.magnitude > 0) //in there is input scale acceleration over time
        {
            accelerationTimer += Time.deltaTime; // increase the acceleration time
        }
        else
        {
            accelerationTimer = 0f; //reset acc timer
        }

        float scaledForceMultiplier = baseAcceleration + (accelerationScale + accelerationTimer);
       
        Vector3 movementForce = new Vector3(moveInput.x, 0, moveInput.z) * scaledForceMultiplier;
        rb.AddForce(movementForce, ForceMode.Acceleration);

        if (rb.linearVelocity.magnitude > maxVelocity)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxVelocity;
        }

        Debug.Log($"Velocity: {rb.linearVelocity.magnitude}");
        Debug.Log($"Acceleration Timer: {accelerationTimer}");
        Debug.Log($"Current Scaled Force Multiplier: {scaledForceMultiplier}");
        Debug.Log($"Move Input X: {moveInput.x}, Z: {moveInput.z}");
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector3>().normalized * speedMultiplier;
        Debug.Log($"Move Input Received: {moveInput}");
    }

}