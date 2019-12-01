using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] Text highScorerName;
    [SerializeField] Text highScore;
    [SerializeField] GameObject highScorePanel;
    [SerializeField] GameObject blanckHighScore;
    private void OnEnable()
    {
        if (SaveSystem.loadData("High_Score") != null)
        {
            highScorePanel.SetActive(true);
            blanckHighScore.SetActive(false);
            string highScoreJson = SaveSystem.loadData("High_Score");
            SaveDataStruct saveDataStructTemp = JsonUtility.FromJson<SaveDataStruct>(highScoreJson);
            highScorerName.text = "" + saveDataStructTemp.name;
            highScore.text = "" + saveDataStructTemp.highScore;
        }
        else
        {
            highScorePanel.SetActive(false);
            blanckHighScore.SetActive(true);
        }
    }
}
