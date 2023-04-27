using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Uga : MonoBehaviour
{

    public Button switchSceneButton;

    void Start()
    {
        // Find the button component on the same game object and add the SwitchScene method to its OnClick event
        Button btn = switchSceneButton.GetComponent<Button>();
        btn.onClick.AddListener(SwitchScene);
    }
    void SwitchScene()
    {
        SceneManager.LoadScene("Scene2", LoadSceneMode.Single); // Replace "SceneName" with the name of the scene you want to switch to
    }
}