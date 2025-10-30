using UnityEngine;

public class PlayerAutoMovement : MonoBehaviour
{
    Rigidbody rb;

    public float moveForce = 20f;
    public float maxSpeed = 10f;

    public float jumpForce = 2f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        rb.AddForce(0, 0, moveForce);

        if(rb.linearVelocity.magnitude > maxSpeed) {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }
}
