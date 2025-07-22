using UnityEngine;

public class PaddleControl2 : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float verticalInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical2");
    }
    void FixedUpdate() {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalInput * speed);
    }
}
