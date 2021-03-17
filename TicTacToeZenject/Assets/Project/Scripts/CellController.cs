using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CellController : MonoBehaviour
{
    PlayerSymbol cellPlayerSymbol;

    GameController _gameController;

    [Inject]
    public void Init(GameController gameController)
    {
        SetPlayerSymbol(PlayerSymbol.Void);
        _gameController = gameController;
    }

    //IF BUTTON WAS CLICKED
    public void ButtonChangeState()
    {
        if (cellPlayerSymbol == PlayerSymbol.Void && !_gameController.IsGameRestarting())
        {
            SetPlayerSymbol(_gameController.GetPlayerSymbol());
            _gameController.Turn();
        }
    }

    //CHANGES CELLS SYMBOL AND CHANGES TEXT
    public void SetPlayerSymbol(PlayerSymbol state)
    {
        cellPlayerSymbol = state;
        GetComponentInChildren<Text>().text = (cellPlayerSymbol == PlayerSymbol.Void ? "" : cellPlayerSymbol.ToString());
    }

    //RETURNS CELLS SYMBOL
    public PlayerSymbol GetPlayerSymbol()
    {
        return cellPlayerSymbol;
    }
}
