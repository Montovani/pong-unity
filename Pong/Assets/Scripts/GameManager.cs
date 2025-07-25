using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    public void AddScore(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score++;
        }
        else if (playerNumber == 2)
        {
            player2Score++;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player1Score == 5)
        {
            Debug.Log("Player 1 win");
            StartCoroutine(ResetGame());
        }
        if (player2Score == 5)
        {
            Debug.Log("Player 2 win");
            StartCoroutine(ResetGame());
        }
    }
   private IEnumerator ResetGame()
   {
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
