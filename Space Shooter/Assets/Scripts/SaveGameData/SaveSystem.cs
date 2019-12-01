using System.IO;
using System;
using UnityEngine;

public static class SaveSystem
{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE
    static readonly string SAVE_FILE_PATH = Application.dataPath + "/GameData/";
#elif UNITY_ANDROID
    static readonly string SAVE_FILE_PATH = Application.persistentDataPath + "/GameData/";
#endif

    public static void init()
    {
        if (!Directory.Exists(SAVE_FILE_PATH))
        {
            Directory.CreateDirectory(SAVE_FILE_PATH);
        }
    }

    public static void saveData(string jsonDataToSave, string fileName)
    {
        try
        {
            Debug.Log("In SaveSystem path : "+ SAVE_FILE_PATH + fileName + ".txt");
            File.WriteAllText(SAVE_FILE_PATH + fileName + ".txt", jsonDataToSave);
        }
        catch(Exception e)
        {
            Debug.Log(e.GetBaseException());
        }
    }

    public static string loadData(string fileName)
    {
        if (File.Exists(SAVE_FILE_PATH + fileName + ".txt"))
        {
            string saveFileData = File.ReadAllText(SAVE_FILE_PATH + fileName + ".txt");
            return saveFileData;
        }
        else
        {
            return null;
        }
    }
}
