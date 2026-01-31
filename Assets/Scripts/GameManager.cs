using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    int playerCard;
    int mimeCard;
    int winner; // 0 - draw, 1 - player, 2 - mime

    public void SelectCard(int card)
    {
        playerCard = card;
        Debug.Log("player selected: " + playerCard);
        StartRound();
    }

    void SelectMimeCard()
    {
        mimeCard = Random.Range(0, 3);
        Debug.Log("Mime selected: " + mimeCard);
        // display sprite
    }

    void CalculateWinner()
    {
        winner = (playerCard - mimeCard + 3) % 3;
        Debug.Log("Winner: " + winner);
        // display winner massage
    }

    void StartRound()
    {
        SelectMimeCard();
        CalculateWinner();
        // calcualte reward
        // reset for new round
    }
}
