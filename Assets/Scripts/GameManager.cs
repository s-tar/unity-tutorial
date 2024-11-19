using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public string playerName;
    public string highScorePlayerName;
    public int highScore;    

    [System.Serializable]
    private class HighScoreData
    {
        public string playerName;
        public int highScore;    
    }
    
    void Awake()
    {
        if(Instance != null) Destroy(this);
        
        Instance = this;
        DontDestroyOnLoad(this);

        LoadHighScore();
    }

    public void SetHighScore(string playerName, int scores)
    {
        if (scores <= highScore) return;
        
        highScore = scores;
        highScorePlayerName = playerName;
    }
    
    public void SaveHighScore()
    {
        var json = JsonUtility.ToJson(new HighScoreData
        {
            playerName = playerName,
            highScore = highScore
        });
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    void LoadHighScore()
    {
        var filePath = Application.persistentDataPath + "/highscore.json";
        if (!File.Exists(filePath)) return;
        
        var data = JsonUtility.FromJson<HighScoreData>(File.ReadAllText(filePath));
        highScorePlayerName = data.playerName;
        highScore = data.highScore;
    }
}
