using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 5f; //Velocity of the paddle that you can configure because it is public
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
    }
}
