using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rd;
    private Vector2 direction;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(1f, -1f);
        direction = new Vector2(x, y).normalized;
        
    }
    void FixedUpdate()
    {
        rd.linearVelocity = direction * speed;
    }
   void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        float paddleY = collision.transform.position.y;
        float ballY = transform.position.y;

        float difference = ballY - paddleY;
        float paddleHeight = collision.collider.bounds.size.y;
        float normalizedY = difference / (paddleHeight / 2);

        direction = new Vector2(-direction.x, normalizedY).normalized;
    }
}
}
