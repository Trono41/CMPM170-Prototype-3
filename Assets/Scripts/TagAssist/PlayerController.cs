using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float velocity = 5;
    [SerializeField] float jumpHeight = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * velocity;

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // Move the player
        // Time.deltaTime ensures consistent movement speed across different frame rates
        rb.linearVelocity = new Vector3(horizontalInput, 0f, 0f);
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpHeight, 0);
        }
    }
}
