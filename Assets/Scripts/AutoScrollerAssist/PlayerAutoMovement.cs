using UnityEngine;

public class PlayerAutoMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float moveForce = 8f;
    public float maxSpeed = 10f;

    public float jumpForce = 10f;
    public bool isGrounded = true;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        rb.AddForce(0, 0, moveForce);

        Vector3 velocity = rb.linearVelocity;

        if (Mathf.Abs(velocity.z) > maxSpeed)
        {
            velocity.z = Mathf.Sign(velocity.z) * maxSpeed;
            rb.linearVelocity = velocity;
        }
    }



    void OnMouseDown()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
