using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public int gridWidth;
    public int gridHeight;

    public int columns = 0;
    public int rows = 0;

    public GameObject gridSquare;

    public Vector2 startPosition = new Vector2(0.0f, 0.0f);

    public float squareScale = 0.5f;
    public float everySquareOffset = 0.0f;
    public float squareGap = 0.1f;


    private Vector2 offSet = new Vector2(0.0f, 0.0f);
    private List<GameObject> gridSquares = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateGrid()
    {
        SpawnGridSquares();
        SetGridSquaresPositions();
    }


    private void SpawnGridSquares()
    {
        {

            int squareIndex = 0;

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; ++column)
                {
                    gridSquares.Add(Instantiate(gridSquare) as GameObject);

                    gridSquares[gridSquares.Count - 1].transform.SetParent(this.transform);
                    gridSquares[gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);
                    gridSquares[gridSquares.Count - 1].GetComponent<GridSquare>().SetImage(squareIndex % 2 == 0);
                    squareIndex++;
                }
            }

        }

    }
    private void SetGridSquaresPositions()
    {
        int columnNumber = 0;
        int rowNumber = 0;
        Vector2 squareGapNumber = new Vector2(0.0f, 0.0f);
        bool rowMoved = false;

        var squareRect = gridSquares[0].GetComponent<RectTransform>();

        offSet.x = squareRect.rect.width * squareRect.transform.localScale.x + everySquareOffset;
        offSet.y = squareRect.rect.height * squareRect.transform.localScale.y + everySquareOffset;

        foreach (var square in gridSquares)
        {
            if (columnNumber + 1 > columns)
            {
                squareGapNumber.x = 0; // goes to next column
                columnNumber = 0;
                rowNumber++;
                rowMoved = true;
            }

            var posXOffset = offSet.x * columnNumber + (squareGapNumber.x * squareGap);
            var posYOffset = offSet.y * rowNumber + (squareGapNumber.y * squareGap);

            if (columnNumber > 0 && columnNumber % 5 == 0)
            {
                squareGapNumber.x++;
                posXOffset += squareGap;
            }

            if (rowNumber > 0 && rowNumber % 5 == 0 && rowMoved == false)
            {
                rowMoved = true;
                squareGapNumber.y++;
                posYOffset += squareGap;
            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPosition.x + posXOffset, startPosition.y - posYOffset);

            square.GetComponent<RectTransform>().localPosition = new Vector3(startPosition.x + posXOffset, startPosition.y - posYOffset, 0.0f);

            columnNumber++;
        }


    }
}