using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering;

public class PlayerController : MonoBehaviour
{
    public float velocity = 5;
    private Rigidbody rb;
    public InputAction moveInput;
    public InputAction jumpInput;
    private bool jumping = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput.Enable();
        jumpInput.Enable();
        rb = GetComponent<Rigidbody>();
        rb.maxLinearVelocity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(moveInput.ReadValue<float>() * velocity, 0, 0);
        if (jumpInput.triggered && jumping == false)
        {
            jumping = true;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 10f, 0);
        }
        if (rb.position.y == 1)
        {
            jumping = false;
        }
    }

}
