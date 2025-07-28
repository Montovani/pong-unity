using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rd;
    private float xInput;
    private float playerJump;
    private bool isGrounded;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        playerJump = Input.GetAxis("Jump");
    }
    void FixedUpdate()
    {
        rd.linearVelocity = new Vector2(xInput * speed, rd.linearVelocity.y);
        if (isGrounded == true && playerJump > 0)
        {
            rd.linearVelocity = new Vector2(rd.linearVelocity.x, playerJump * speed);
        }
        else
        {
            rd.linearVelocity = new Vector2(rd.linearVelocity.x, rd.linearVelocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }


}
