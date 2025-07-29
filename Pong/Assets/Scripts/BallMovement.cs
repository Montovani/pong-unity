using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rd;
    private Vector2 direction;
    private GameManager gameManager;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(1f, -1f);
        direction = new Vector2(x, y).normalized;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    void FixedUpdate()
    {
        if (gameManager.GetCurrentState() != GameManager.GameState.Playing)
            {
                rd.linearVelocity = Vector2.zero;
                return;
            }
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
            direction = new Vector2(direction.x, -direction.y);
        }
        if (collision.gameObject.CompareTag("LeftGoal"))
        {
            gameManager.AddScore(2);
            StartCoroutine(ResetBall());
            Debug.Log(gameManager.player2Score);
        }
        if (collision.gameObject.CompareTag("RightGoal"))
        {
            gameManager.AddScore(1);
            StartCoroutine(ResetBall());
            Debug.Log(gameManager.player1Score);
        }

    }
    private IEnumerator ResetBall()
    {
        direction = Vector2.zero;
        transform.position = new Vector2(0, 0);
        yield return new WaitForSeconds(2f);
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(1f, -1f);
        direction = new Vector2(x, y).normalized;
    }
}
