using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerInputManager : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 moveInput = Vector3.zero;
    public Transform playerMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMove = GetComponent<Transform>();



    }


    void FixedUpdate()
    {

        Vector3 newPosition = rb.position + new Vector3(moveInput.x, 0, moveInput.z) * Time.deltaTime;
        rb.MovePosition(newPosition);

        Debug.Log($"Velocity: {rb.linearVelocity}");
        Debug.Log($"Angular Velocity: {rb.angularVelocity}");


    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector3>().normalized;
        Debug.Log($"Move Input Received: {moveInput}");
    }

}