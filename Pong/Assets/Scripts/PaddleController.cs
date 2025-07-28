using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 5f; //Velocity of the paddle that you can configure because it is public
    private Rigidbody2D rb;           // Referência ao componente Rigidbody2D
    private float verticalInput;      // Armazena o valor do input do jogador
    void Start()
    {
        // Pegamos o componente Rigidbody2D do próprio GameObject
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Captura o input do jogador (teclas W/S ou setas se configurar Vertical2)
        verticalInput = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        // Aplica a velocidade vertical com base no input
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalInput * speed);
    }
}
