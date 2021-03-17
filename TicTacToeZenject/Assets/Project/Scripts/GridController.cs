using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridController : MonoBehaviour
{
    public CellController[,] cellGrid;

    void Start()
    {
        cellGrid = new CellController[3, 3];
        ReadGrid();
    }

    void ReadGrid()
    {
        for (int i = 0; i < cellGrid.GetLength(0); i++)
        {
            for (int j = 0; j < cellGrid.GetLength(1); j++)
            {
                cellGrid[i, j] = transform.Find($"Cell{i+j*3+1}").GetComponent<CellController>();
            }
        }
    }

    //CLEARS GRID
    public void ResetGrid()
    {
        foreach (CellController child in cellGrid)
        {
            child.SetPlayerSymbol(PlayerSymbol.Void);
        }
    }

    //CHECK GRID ON WINNING CONDITIONS
    public PlayerSymbol CheckGameWinner()
    {
        for (int i = 0; i < cellGrid.GetLength(0); i++)
        {
            for (int j = 0; j < cellGrid.GetLength(1); j++)
            {
                Debug.Log($"[{i},{j}]{cellGrid[i, j].GetPlayerSymbol()}");
            }
        }

        Debug.Log("------------------------------------------------");

        for (int i = 0; i < 3; i++)
        {
            if (cellGrid[i, 0].GetPlayerSymbol() != PlayerSymbol.Void && cellGrid[i, 0].GetPlayerSymbol() == cellGrid[i, 1].GetPlayerSymbol() && cellGrid[i, 1].GetPlayerSymbol() == cellGrid[i, 2].GetPlayerSymbol())
            {
                return cellGrid[i, 0].GetPlayerSymbol();
            }
            else if (cellGrid[0, i].GetPlayerSymbol() != PlayerSymbol.Void && cellGrid[0, i].GetPlayerSymbol() == cellGrid[1, i].GetPlayerSymbol() && cellGrid[1, i].GetPlayerSymbol() == cellGrid[2, i].GetPlayerSymbol())
            {
                return cellGrid[0, i].GetPlayerSymbol();
            }
        }

        if (cellGrid[0, 0].GetPlayerSymbol() != PlayerSymbol.Void && cellGrid[0, 0].GetPlayerSymbol() == cellGrid[1, 1].GetPlayerSymbol() && cellGrid[1, 1].GetPlayerSymbol() == cellGrid[2, 2].GetPlayerSymbol())
        {
            return cellGrid[0, 0].GetPlayerSymbol();
        }

        if (cellGrid[2, 0].GetPlayerSymbol() != PlayerSymbol.Void && cellGrid[2, 0].GetPlayerSymbol() == cellGrid[1, 1].GetPlayerSymbol() && cellGrid[1, 1].GetPlayerSymbol() == cellGrid[0, 2].GetPlayerSymbol())
        {
            return cellGrid[2, 0].GetPlayerSymbol();
        }

        int counter = 0;

        foreach (CellController item in cellGrid)
        {
            if (item.GetPlayerSymbol() != PlayerSymbol.Void)
            {
                counter++;
            }
        }

        if (counter == 9)
        {
            ResetGrid();
        }

        return PlayerSymbol.Void;
    }
}
