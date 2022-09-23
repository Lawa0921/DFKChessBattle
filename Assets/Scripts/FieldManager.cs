using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public RowManager[] allRows;
    public BattleHex[,] allHexesArray;
    void Start()
    {
        allRows = GetComponentsInChildren<RowManager>();

        for (int i = 0; i < allRows.Length; i++)
        {
            allRows[i].allHexesInRow = allRows[i].GetComponentsInChildren<BattleHex>();
        }
        CreateAllHexesArray();
        CreateActiveHexesArray();
    }

    private void CreateAllHexesArray()
    {
        int heightOfArray = allRows.Length;
        int widthOfArray = allRows[0].allHexesInRow.Length;
        allHexesArray = new BattleHex[widthOfArray, heightOfArray];

        for (int i = 0; i < heightOfArray; i++)
        {
            for (int j = 0; j < widthOfArray; j++)
            {
                allHexesArray[j, i] = allRows[i].allHexesInRow[widthOfArray - j - 1];
                allHexesArray[j, i].verticalCoordinate = heightOfArray - i;
                allHexesArray[j, i].horizontalCoordinate = widthOfArray - j;
            }
        }
    }

    private void CreateActiveHexesArray()
    {
        foreach (BattleHex hex in allHexesArray)
        {
            if (Mathf.Abs(hex.transform.position.x) > 8.5f || Mathf.Abs(hex.transform.position.y) > 4.5f )
            {
                hex.SetInActive();
            }
            else
            {
                hex.SetActive();
            }
        }
    }
}
