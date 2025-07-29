using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    public enum GameState
    {
        WaitingToStart,
        Playing,
        GameOver
    }
    public GameObject startText;
    private GameState currentState = GameState.WaitingToStart;
    public GameObject player01WinsText;
    public GameObject player02WinsText;
    public TextMeshProUGUI player01ScoreText;
    public TextMeshProUGUI player02ScoreText;

    public void AddScore(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score++;
            player01ScoreText.text = $"Player 01: {player1Score}";
        }
        else if (playerNumber == 2)
        {
            player2Score++;
            player02ScoreText.text = $"Player 02: {player1Score}";
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player01WinsText.SetActive(false);
        player02WinsText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == GameState.Playing || currentState == GameState.WaitingToStart)
        {
            player01WinsText.SetActive(false);
            player02WinsText.SetActive(false);
        }
        if (currentState == GameState.WaitingToStart && Input.GetKeyDown(KeyCode.Space))
        {
            currentState = GameState.Playing;
            startText.SetActive(false);
        }

        if (player1Score == 5)
        {
            Debug.Log("Player 1 win");
            player01WinsText.SetActive(true);
            StartCoroutine(ResetGame());
        }
        if (player2Score == 5)
        {
            Debug.Log("Player 2 win");
            player02WinsText.SetActive(true);
            StartCoroutine(ResetGame());
        }
    }
    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public GameState GetCurrentState()
    {
        return currentState;
    }
}
