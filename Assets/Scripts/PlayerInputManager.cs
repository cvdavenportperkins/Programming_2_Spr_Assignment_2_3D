using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerInputManager : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 moveInput = Vector3.zero;
    public Transform playerMove;
    public float speedMultiplier = 5f;
    public float forceMultiplier = 10f;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMove = GetComponent<Transform>();



    }


    void FixedUpdate()
    {

        Vector3 movementForce = new Vector3(moveInput.x, 0, moveInput.z) * forceMultiplier;
        rb.AddForce(movementForce, ForceMode.Acceleration);

        Debug.Log($"Velocity: {rb.linearVelocity}");
        Debug.Log($"Angular Velocity: {rb.angularVelocity}");


    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector3>().normalized * speedMultiplier;
        Debug.Log($"Move Input Received: {moveInput}");
    }

}