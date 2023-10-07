using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string playerName;
    public int highscore;
    public string playerNameHighscore;
    


    private void Awake()
    {
        instance = this;
        LoadHighscore();
        DontDestroyOnLoad(gameObject);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quitgame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    [System.Serializable]
    public class SaveData
    {
        public int highscore;
        public string playerNameHighscore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;
        data.playerNameHighscore = playerNameHighscore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/SaveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highscore = data.highscore;
            playerNameHighscore = data.playerNameHighscore;

        }
    }
}
