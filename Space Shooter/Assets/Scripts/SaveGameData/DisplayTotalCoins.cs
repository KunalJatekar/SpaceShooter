using UnityEngine;
using UnityEngine.UI;

public class DisplayTotalCoins : MonoBehaviour
{
    [SerializeField] Text totalCoinText;
    private void OnEnable()
    {
        if (SaveSystem.loadData("High_Score") != null)
        {
            string highScoreJson = SaveSystem.loadData("High_Score");
            SaveDataStruct saveDataStructForCoinTemp = JsonUtility.FromJson<SaveDataStruct>(highScoreJson);
            totalCoinText.text = ""+saveDataStructForCoinTemp.coinCount;
        }
        else
        {
            totalCoinText.text = "0";
        }
    }
}
