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
}
