using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class My : MonoBehaviour
{
    private string previousSceneName;
    private static bool puzzleDestroyed = false;
    private static bool puzleDestroyed = false;

    void Start()
    {
        //https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe first
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
       
        //https://forum.unity.com/threads/using-only-one-eventsystem.1330017/
        DontDestroyOnLoad(gameObject);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        if(puzzleDestroyed)
        {
            Destroy(GameObject.FindGameObjectWithTag("puzle"));
        }

        if (puzleDestroyed)
        {
            Destroy(GameObject.FindGameObjectWithTag("puzzle"));
        }

        if (previousSceneName == "Scene1" && scene.name == "Scene" && !puzleDestroyed)
        {
            Debug.Log("Transitioning from Scene 1 to Scene");
            // Do something when going from Scene 1 to Scene 2
           Destroy(GameObject.FindGameObjectWithTag("puzle"));
            puzleDestroyed = true;

                Debug.Log("Destroyed puzle");
         
        }
        else if (previousSceneName == "Scene2" && scene.name == "Scene" && !puzzleDestroyed)
        {
            Debug.Log("Transitioning from Scene 2 to Scene");
            // Do something when going from Scene 3 to Scene 4
          Destroy(GameObject.FindGameObjectWithTag("puzzle"));
            puzzleDestroyed = true;
          
           
            Debug.Log("Destroyed puzzle");
        }

        previousSceneName = scene.name; // Update the previous scene name
    }
  
}
