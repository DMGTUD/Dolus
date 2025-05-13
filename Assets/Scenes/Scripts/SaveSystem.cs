using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct GameStatus 
{
    public int level;
    public int deathCount;
}

public class SaveSystem : MonoBehaviour
{
    public GameStatus gameStatus;
    string filePath;
    const string saveFileName = "SaveStatus.json";
    private static GameObject sampleInstance;

    private void Awake()
    {
        if (sampleInstance != null)
            Destroy(sampleInstance);

        sampleInstance = gameObject;
        DontDestroyOnLoad(this);
    }
    
    void Start()
    {
        filePath = Application.persistentDataPath;
        gameStatus = new GameStatus();
        Debug.Log(filePath);
        LoadGameStatus();
    }
        
        

    public void LoadGameStatus()
    {
        
        if (File.Exists(filePath + "/" + saveFileName)) 
        {
            string loadedJson = File.ReadAllText (filePath + "/" + saveFileName);
            gameStatus = JsonUtility.FromJson<GameStatus>(loadedJson);
            Debug.Log ("File loaded successfully");
        } 
        else 
        {
            Debug.Log ("File not found");
            ResetSave();
        }
    }
    public void SaveGameStatus()
    {
        string gameStatusJson = JsonUtility.ToJson(gameStatus);
        File.WriteAllText(filePath + "/" + saveFileName, gameStatusJson);
        Debug.Log("File created and saved");
    }

    public void Update()
    {
        

    }

    public void AddLevel()
    {
        gameStatus.level++;
        SaveGameStatus();
    }

    public void AddDeath()
    {
        gameStatus.deathCount++;
        SaveGameStatus();
    }

    public void ResetSave()
    {
        gameStatus.level=0;
        gameStatus.deathCount=0;
        Debug.Log("Save File Reset");
        SaveGameStatus();
    }

}




