using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


[Serializable]
public struct GameStatus2
{
public string playerName;
public int currentLevel;
public string spawnPoint;
public int health;
public int coins;
}
public class TestCode : MonoBehaviour
{
GameStatus2 gameStatus;
string filePath;
const string FILE_NAME = "SaveStatus.json";
//build our UI controls- a simple label


//this function loads a saving file if found
public void LoadGameStatus ()
{
    //always check the file exists
    if (File.Exists (filePath + "/" + FILE_NAME)) 
    {
        //load the file content as string
        string loadedJson = File.ReadAllText (filePath + "/" + FILE_NAME);
        //deserialise the loaded string into a GameStatus2 struct
        gameStatus = JsonUtility.FromJson<GameStatus2> (loadedJson);
        Debug.Log ("File loaded successfully");
    } 
    else 
    {
        //initilise a new game status
        gameStatus.playerName = "Keith";
        gameStatus.currentLevel = 1;
        gameStatus.spawnPoint = "Beginning";//reference to a game object
        gameStatus.health = 100;
        gameStatus.coins = 0;
        Debug.Log ("File not found");
    }
}
//this function overrides the saving file
public void SaveGameStatus ()
{
    //serialise the GameStatus2 struct into a Json string
    string gameStatusJson = JsonUtility.ToJson (gameStatus);
    //write a text file containing the string value as simple text
    File.WriteAllText (filePath + "/" + FILE_NAME, gameStatusJson);
    Debug.Log ("File created and saved");
}
// Use this for initialization
void Start ()
{
    //retrieving saving location
    filePath = Application.persistentDataPath;
    gameStatus = new GameStatus2 ();
    Debug.Log (filePath);
    //startup initialisation
    LoadGameStatus ();
}
// Update is called once per frame
void Update ()
{
}
}

