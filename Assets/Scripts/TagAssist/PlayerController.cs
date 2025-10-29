using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering;

public class PlayerController : MonoBehaviour
{
    public float velocity = 5;
    private Rigidbody rb;
    public InputAction moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput.Enable();
        rb = GetComponent<Rigidbody>();
        rb.maxLinearVelocity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(moveInput.ReadValue<float>() * velocity, 0, 0);
    }

}
