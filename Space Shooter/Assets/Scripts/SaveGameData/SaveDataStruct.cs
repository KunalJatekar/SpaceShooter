using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SaveDataStruct
{
    public string name;
    public int highScore;
    public int coinCount;

    public string Name
    {
        set
        {
            name = value;
        }
    }

    public int HighScore
    {
        set
        {
            highScore = value;
        }
    }

    public int CoinCount
    {
        set
        {
            coinCount = value;
        }
    }
}
