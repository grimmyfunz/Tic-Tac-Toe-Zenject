using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public Cell[,] cellGrid;
    [SerializeField]
    GameObject cellPrefab;

    void Start()
    {
        cellGrid = new Cell[3, 3];
        FillGrid();
    }

    //CLEARS AND FILLS GRID WITH EMPTY CELLS
    public void FillGrid()
    {
        ClearGrid();

        for (int i = 0; i < cellGrid.GetLength(0); i++)
        {
            for (int j = 0; j < cellGrid.GetLength(1); j++)
            {
                GameObject cellInstance = Instantiate(cellPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                cellInstance.transform.SetParent(transform);
                cellGrid[i,j] = cellInstance.GetComponent<Cell>();
                Debug.Log(cellGrid[i, j].GetPlayerSymbol().ToString());
            }
        }
    }

    //CLEARS GRID
    void ClearGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    //CHECK GRID ON WINNING CONDITIONS
    public PlayerSymbol CheckGameWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if (cellGrid[i, 0].GetPlayerSymbol() != PlayerSymbol.Void && cellGrid[i, 0].GetPlayerSymbol() == cellGrid[i, 1].GetPlayerSymbol() && cellGrid[i, 1].GetPlayerSymbol() == cellGrid[i, 2].GetPlayerSymbol())
            {
                return cellGrid[i, 0].GetPlayerSymbol();
            }
            else if (cellGrid[0, i].GetPlayerSymbol() != PlayerSymbol.Void && cellGrid[0, i].GetPlayerSymbol() == cellGrid[1, i].GetPlayerSymbol() && cellGrid[1, i].GetPlayerSymbol() == cellGrid[2, i].GetPlayerSymbol())
            {
                return cellGrid[0, 1].GetPlayerSymbol();
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

        foreach (Cell item in cellGrid)
        {
            if (item.GetPlayerSymbol() != PlayerSymbol.Void)
            {
                counter++;
            }
        }

        if (counter == 9)
        {
            FillGrid();
        }

        return PlayerSymbol.Void;
    }
}
