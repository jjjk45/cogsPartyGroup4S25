using UnityEngine;
using UnityEngine.InputSystem;

public class BoatScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float maxFallingSpeed = -10f;
    public float maxRisingSpeed = 10f;
    public float maxHorizontalSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0, maxFallingSpeed);
    }

    // Update is called once per frame, Fixedupdate is called more sparingly
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))    {
            rb.linearVelocityY = -3;
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))  {
            rb.linearVelocityX = 0;
        }
    }
    void FixedUpdate()
    {
        verticalMovement();
        horizontalMovement();
    }
    void verticalMovement() {
        if(rb.linearVelocityY < maxFallingSpeed)    {
            rb.linearVelocityY = maxFallingSpeed;
        }
        if(Input.GetKey(KeyCode.W)) {
            if(rb.linearVelocityY < maxRisingSpeed) {
                rb.linearVelocityY += 1;
            }
        }
        else    {
            rb.linearVelocityY -= 1;
        }
    }
    void horizontalMovement()   {
        if(Input.GetKey(KeyCode.A)) {
            if(rb.linearVelocityX > maxHorizontalSpeed * -1) {
                rb.linearVelocityX -= 1;
            }
        }
        if(Input.GetKey(KeyCode.D)) {
            if(rb.linearVelocityX < maxHorizontalSpeed) {
                rb.linearVelocityX += 1;
            }
        }
    }
}