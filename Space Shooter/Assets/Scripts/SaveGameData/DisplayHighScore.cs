using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayHighScore : MonoBehaviour
{
    public Text highScoreText;
    public Text currentScoreText;

    GameManager gameManager;

    void OnEnable()
    {
        highScoreText.text = "";
        currentScoreText.text = "";
        gameManager = FindObjectOfType<GameManager>();
        if (SaveSystem.loadData("High_Score") != null)
        {
            string highScoreJson = SaveSystem.loadData("High_Score");
            SaveDataStruct saveData = JsonUtility.FromJson<SaveDataStruct>(highScoreJson);
            if (saveData.highScore != 0)
            {
                highScoreText.text = "" + saveData.highScore;
                currentScoreText.text = "" + gameManager.scoreCount;
            }
            else
            {
                highScoreText.text = "" + gameManager.scoreCount;
                currentScoreText.text = "" + gameManager.scoreCount;
            }
        }
        else
        {
            highScoreText.text = "" + gameManager.scoreCount;
            currentScoreText.text = "" + gameManager.scoreCount;
        }
    }
}
