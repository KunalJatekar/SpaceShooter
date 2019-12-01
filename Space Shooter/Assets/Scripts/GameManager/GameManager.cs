using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Slider healthBar;
    [SerializeField] GameObject[] gameObjectToEnableOnPlay;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject endMenuCanvas;
    [SerializeField] GameObject highScoreCanvas;
    [SerializeField] GameObject settingMenuCanvas;
    [SerializeField] GameObject highScoreDisplayCanvas;
    [SerializeField] GameObject totalCoinsCanvas;

    [SerializeField] GameEvent restartEvent;

    Health playerHealth;
    public int scoreCount;
    public int coinCount;
    public bool enableComponent;
    Vector3 playerStartPosition;
    Camera mainCamera;
    AudioSource mainSound;

    void Awake()
    {
        SaveSystem.init();
    }

    // Start is called before the first frame update
    void Start()
    {
        enableComponent = false;
        if (player == null)
        {
            return;
        }
        playerHealth = player.GetComponent<Health>();
        playerStartPosition = player.transform.position;
        scoreCount = 0;
        coinCount = 0;
        mainCamera = Camera.main;
        mainSound = mainCamera.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText == null)
        {
            return;
        }
        scoreText.text = "Score : " + scoreCount + "\n Coins : " + coinCount;
        healthBar.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if(playerHealth == null)
        {
            return;
        }
        healthBar.value = playerHealth.currentHealth;
    }

    public void Play()
    {
        //restartEvent.Raise();
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        player.SetActive(true);
        player.transform.position = playerStartPosition;
        foreach (GameObject gameObject in gameObjectToEnableOnPlay)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = Vector3.zero;
        }

        pauseMenuCanvas.SetActive(false);
        endMenuCanvas.SetActive(false);
        mainSound.Stop();

        enableComponent = false;
        scoreCount = 0;
        coinCount = 0;
        playerHealth.currentHealth = playerHealth.startHealth;
        mainMenuCanvas.SetActive(false);
    }

    public void Restart()
    {
        restartEvent.Raise();
        enableComponent = true;
        //SceneManager.LoadScene(0);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        
        player.SetActive(true);
        player.transform.position = playerStartPosition;
        foreach (GameObject gameObject in gameObjectToEnableOnPlay)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = Vector3.zero;
        }

        GameObject[] bullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject gameObject in bullet)
        {
            Destroy(gameObject);
        }

        pauseMenuCanvas.SetActive(false);
        endMenuCanvas.SetActive(false);
        scoreCount = 0;
        coinCount = 0;
        playerHealth.currentHealth = playerHealth.startHealth;
        mainMenuCanvas.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenuCanvas.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        scoreText.text = "Score : " + scoreCount;
        healthBar.gameObject.SetActive(true);
        healthBar.value = playerHealth.currentHealth;
        pauseMenuCanvas.SetActive(false);
        endMenuCanvas.SetActive(false);
    }

    public void Home()
    {
        restartEvent.Raise();
        scoreCount = 0;
        coinCount = 0;
        playerHealth.currentHealth = playerHealth.startHealth;

        player.SetActive(false);
        foreach (GameObject gameObject in gameObjectToEnableOnPlay)
        {
            gameObject.SetActive(false);
        }
        GameObject[] bullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject gameObject in bullet)
        {
            Destroy(gameObject);
        }
        GameObject[] playerBullet = GameObject.FindGameObjectsWithTag("PlayerBullet");
        foreach (GameObject gameObject in playerBullet)
        {
            Destroy(gameObject);
        }
        pauseMenuCanvas.SetActive(false);
        endMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
        mainSound.Play();
        enableComponent = true;
    }

    public void ShowEndMenu()
    {
        Time.timeScale = 0;
        if (SaveSystem.loadData("High_Score") != null)
        {
            string highScoreJson = SaveSystem.loadData("High_Score");
            SaveDataStruct saveDataStruct = JsonUtility.FromJson<SaveDataStruct>(highScoreJson);
            if (saveDataStruct.highScore == 0)
            {
                highScoreCanvas.SetActive(true);
            }
            else if (scoreCount > saveDataStruct.highScore)
            {
                highScoreCanvas.SetActive(true);
            }
            else
            {
                enableComponent = false;
                pauseMenuCanvas.SetActive(false);
                endMenuCanvas.SetActive(true);
            }
        }
        else
        {
            highScoreCanvas.SetActive(true);
        }
    }

    public void saveHighScore(InputField inputField)
    {
        Debug.Log("Inside GameManager name : " + inputField.text);
        SaveDataStruct saveDataStruct = new SaveDataStruct();
        saveDataStruct.Name = inputField.text;
        //saveDataStruct.Name = "Kunal";
        saveDataStruct.HighScore = scoreCount;
        if (SaveSystem.loadData("High_Score") == null)
        {
            saveDataStruct.CoinCount = coinCount;
        }
        else
        {
            if (SaveSystem.loadData("High_Score") != null)
            {
                string highScoreJson = SaveSystem.loadData("High_Score");
                SaveDataStruct saveDataStructForCoinTemp = JsonUtility.FromJson<SaveDataStruct>(highScoreJson);
                if (saveDataStructForCoinTemp.coinCount == 0)
                {
                    saveDataStruct.CoinCount = coinCount;
                }
                else if (saveDataStructForCoinTemp.coinCount > 0)
                {
                    int totalCoins = saveDataStructForCoinTemp.coinCount + coinCount;
                    saveDataStruct.CoinCount = totalCoins;
                }
                else
                {
                    saveDataStruct.CoinCount = coinCount;
                }
            }
            else
            {
                saveDataStruct.CoinCount = coinCount;
            }

        }

        string finalJson = JsonUtility.ToJson(saveDataStruct, true);
        Debug.Log("Inside GameManager finalJson : " + finalJson);
        SaveSystem.saveData(finalJson, "High_Score");
        enableComponent = false;
        highScoreCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(false);
        endMenuCanvas.SetActive(true);
    }

    public void settings()
    {
        settingMenuCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void goBackToMainMenu()
    {
        settingMenuCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void goBackToSettingMenu()
    {
        totalCoinsCanvas.SetActive(false);
        highScoreDisplayCanvas.SetActive(false);
        settingMenuCanvas.SetActive(true);
    }
    
    public void showTotalCoins()
    {
        totalCoinsCanvas.SetActive(true);
        settingMenuCanvas.SetActive(false);
    }

    public void showHighScore()
    {
        highScoreDisplayCanvas.SetActive(true);
        settingMenuCanvas.SetActive(false);
    }
}
