using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour {
    public static PersistentData Instance;
    private static string _currUserName;
    private static int _highScore;
    private static string _highScoreHolderUserName;
    
    
    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetCurrentUserName(string userName) { _currUserName = userName; }
    public string GetCurrentUserName() { return _currUserName; }
    public void SetHighScore(int newHighScore, string userName) {
        if (newHighScore > _highScore) {
            _highScore = newHighScore;
            _highScoreHolderUserName = _currUserName;
        } else { Debug.Log("PersistentData::SetHighScore() New high score is not greater than the current high score!"); }
    }
    public int GetHighScore() { return _highScore; }
    public void SetHighScoreHolderUserName(string userName) { _highScoreHolderUserName = userName; }
    public string GetHighScoreHolderUserName() { return _highScoreHolderUserName; }
}
