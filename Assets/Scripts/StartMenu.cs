using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    [SerializeField] TMP_InputField _usernameField;
    [SerializeField] TMP_Text _txtMessage;
    
    public void OnStartButtonPress() {
        if (_usernameField.text != string.Empty) { //Store username
            PersistentData.Instance.SetCurrentUserName(_usernameField.text);
        } else { _txtMessage.text = "You must enter a username to continue."; }

        SceneManager.LoadSceneAsync("main", LoadSceneMode.Single);
    }

    public void OnExitButtonPress() {
        //Save high score and high score username
        
        
        Application.Quit();
    }
}
