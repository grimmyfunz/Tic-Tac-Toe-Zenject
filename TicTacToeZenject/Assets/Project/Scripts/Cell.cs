﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    PlayerSymbol cellPlayerSymbol = PlayerSymbol.Void;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    //IF BUTTON WAS CLICKED
    public void ButtonChangeState()
    {
        if (cellPlayerSymbol == PlayerSymbol.Void && !gameManager.IsGameRestarting())
        {
            SetPlayerSymbol(gameManager.GetPlayerSymbol());
            gameManager.Turn();
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

public enum PlayerSymbol
{
    Void,
    X,
    O
}
