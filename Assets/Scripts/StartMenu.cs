using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    [SerializeField] TMP_InputField _usernameField;
    [SerializeField] TMP_Text _txtMessage;


    public void Start() {
        if (PersistentData.Instance.LoadDataFile()) { //File found and loaded
            _usernameField.text = PersistentData.Instance.GetLastUserName(); //Load last used username
            Debug.Log("StartMenu::Start() Load data file found.");
        } else { Debug.Log("StartMenu::Start() Load data file not found.");}
    }
    
    public void OnStartButtonPress() {
        if (_usernameField.text != string.Empty) { //Store username for next scene
            PersistentData.Instance.SetCurrentUserName(_usernameField.text);
        } else { _txtMessage.text = "You must enter a username to continue."; }

        SceneManager.LoadSceneAsync("main", LoadSceneMode.Single);
    }

    public void OnExitButtonPress() { Application.Quit(); }
}
