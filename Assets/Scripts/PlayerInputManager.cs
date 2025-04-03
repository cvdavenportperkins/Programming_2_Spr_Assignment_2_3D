using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerInputManager : MonoBehaviour
{
    public Rigidbody rb;
    public Vector2 moveInput = Vector2.zero;
    public Transform playerMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMove = GetComponent<Transform>();



    }


    void Update()
    {

        Vector3 newPosition = new Vector3(moveInput.x, moveInput.y, 0) + rb.position;
        playerMove.position = newPosition;



    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
        Debug.Log(moveInput);
    }

}