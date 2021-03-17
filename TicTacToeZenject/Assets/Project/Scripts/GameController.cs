using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class GameController : MonoBehaviour
{
    PlayerSymbol playerSymbol;
    GridController _gridController;
    bool gameRestarting = false;
    float restartTimer;
    [SerializeField]
    Text winnerText;

    [Inject]
    GameConfig _config;

    [Inject]
    public void Init(GridController gridController)
    {
        _gridController = gridController;
    }

    void Start()
    {
        restartTimer = _config.ResetTimer;
        playerSymbol = PlayerSymbol.X;
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
        PlayerSymbol winner = _gridController.CheckGameWinner();


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
                _gridController.ResetGrid();
                restartTimer = _config.ResetTimer;
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
