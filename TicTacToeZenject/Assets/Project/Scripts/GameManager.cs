using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerSymbol playerSymbol;
    GameGrid gameGrid;
    bool gameRestarting = false;
    float restartTimer = 5f;
    [SerializeField]
    Text winnerText;

    void Start()
    {
        playerSymbol = PlayerSymbol.X;
        gameGrid = FindObjectOfType<GameGrid>();
    }

    private void Update()
    {
        RestartTimerCounter();
    }

    //RETURNS WHICH PLAYERS TURN IS
    public PlayerSymbol GetPlayerSymbol()
    {
        return playerSymbol;
    }

    //GIVES TURN TO OPPONENT PLAYER
    void PlayerSymbolFlip()
    {
        if (playerSymbol == PlayerSymbol.X)
        {
            playerSymbol = PlayerSymbol.O;
        }
        else
        {
            playerSymbol = PlayerSymbol.X;
        }
    }

    //CHECKS IF GAME IS ENDED
    void CheckGameWinner()
    {
        PlayerSymbol winner = gameGrid.CheckGameWinner();


        if (winner != PlayerSymbol.Void)
        {
            Win(winner);
        }
    }

    //GAME END
    void Win(PlayerSymbol playerSymbol)
    {
        winnerText.text = (playerSymbol + " is a Winner!");
        RestartGame();
    }

    //TIMER FUNCTION
    void RestartTimerCounter()
    {
        if (gameRestarting)
        {
            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0)
            {
                gameRestarting = false;
                gameGrid.FillGrid();
                restartTimer = 5f;
                winnerText.text = "";
            }
        }
    }

    //GAME RESTART
    void RestartGame()
    {
        gameRestarting = true;
    }

    //SUCCESSFUL TURN
    public void Turn()
    {
        PlayerSymbolFlip();
        CheckGameWinner();
    }

    //GETS IS GAME RESTARTING BOOL
    public bool IsGameRestarting()
    {
        return gameRestarting;
    }
}
