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
            float paddleY = collision.transform.position.y; //Aqui pega a posicao y do "player
            float ballY = transform.position.y; //Aqui pega a posicao y da bola

            float difference = ballY - paddleY; //Pegar onde no paddle a bola bateu cima meio ou baixo
            float paddleHeight = collision.collider.bounds.size.y; //colision tinhamos declarado ja, vai pegar o tamanho e posicao do objeto com o .collider depois pega os limites com o .bounds e no final pega o tamanho total do objeto
            float normalizedY = difference / (paddleHeight / 2); //Aqui ve se bateu no centro =0 cima +1 ou baixo -1

            direction = new Vector2(-direction.x, normalizedY).normalized;
        }
        if (collision.gameObject.CompareTag("xLimit"))
        {
            direction = new Vector2(direction.x,-direction.y);
        }
    
    }
}
