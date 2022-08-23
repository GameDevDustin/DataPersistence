using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistentData : MonoBehaviour {
    public static PersistentData Instance;
    private static string _currUserName;
    private static string _lastUserName;
    private static int _highScore;
    private static string _highScoreHolderUserName;
    
    
    private void Awake() {
        if (Instance != null) { Destroy(gameObject); return; }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetCurrentUserName(string userName) { _currUserName = userName; }
    public string GetCurrentUserName() { return _currUserName; }
    public void SetLastUserName(string lastUserName) { _lastUserName = lastUserName; }
    public string GetLastUserName() { return _lastUserName; }
    public void SetHighScore(int newHighScore) {
        if (newHighScore > _highScore) {
            if (_currUserName != string.Empty) {
                _highScore = newHighScore;
                _highScoreHolderUserName = _currUserName;
            } else { Debug.LogError("PersistentData::SetHighScore() PersistantData's current username is empty!"); }
        } else { Debug.Log("PersistentData::SetHighScore() New high score is not greater than the current high score!"); }
    }
    public int GetHighScore() { return _highScore; }
    public void SetHighScoreHolderUserName(string userName) { _highScoreHolderUserName = userName; }
    public string GetHighScoreHolderUserName() { return _highScoreHolderUserName; }
    
    [System.Serializable] public class SaveData {
        public string LastUserName;
        public int HighScore;
        public string HighScoreHolderUserName;
    }

    public void SaveDataFile() {
        SaveData data = new SaveData();
        string json;
        
        data.LastUserName = _currUserName;
        data.HighScore = _highScore;
        data.HighScoreHolderUserName = _highScoreHolderUserName;

        json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/PersistentDataSaveFile.json", json);
    }

    public bool LoadDataFile() {
        SaveData data = new SaveData();
        string path = Application.persistentDataPath + "/PersistentDataSaveFile.json";
        string json;

        if (File.Exists(path)) {
            json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);

            _lastUserName = data.LastUserName;
            _highScore = data.HighScore;
            _highScoreHolderUserName = data.HighScoreHolderUserName;
            return true;
        } else { return false; }
    }
}
