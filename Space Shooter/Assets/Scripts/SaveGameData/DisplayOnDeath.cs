using UnityEngine;
using UnityEngine.UI;

public class DisplayOnDeath : MonoBehaviour
{
    public Text highScoreText;
    public Text coinText;

    GameManager gameManager;

    void OnEnable()
    {
        highScoreText.text = "";
        coinText.text = "";
        gameManager = FindObjectOfType<GameManager>();
        if (SaveSystem.loadData("High_Score") != null)
        {
            string highScoreJson = SaveSystem.loadData("High_Score");
            SaveDataStruct saveData = JsonUtility.FromJson<SaveDataStruct>(highScoreJson);
            if (saveData.highScore != 0)
            {
                highScoreText.text = "" + saveData.highScore;
                coinText.text = "" + gameManager.coinCount;
            }
            else
            {
                highScoreText.text = "" + gameManager.scoreCount;
                coinText.text = "" + gameManager.coinCount;
            }
        }
        else
        {
            highScoreText.text = "" + gameManager.scoreCount;
            coinText.text = "" + gameManager.coinCount;
        }
    }
}
