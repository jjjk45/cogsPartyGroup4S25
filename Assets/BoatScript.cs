using UnityEngine;
using UnityEngine.InputSystem;

public class BoatScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float maxFallingSpeed = -10;
    public float maxRisingSpeed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = maxFallingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        /*Vertical Movement*/
        if(rb.linearVelocityY < maxFallingSpeed)    {
            rb.linearVelocityY = maxFallingSpeed;
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            rb.linearVelocityY = 0;
        }
        if(Input.GetKey(KeyCode.Space)) {
            if(rb.linearVelocityY < maxRisingSpeed) {
                rb.linearVelocityY += 1;
            }
        }
        else    {
            rb.linearVelocityY -= 1;
        }
    }
}
