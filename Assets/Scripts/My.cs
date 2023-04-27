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
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe first
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
        DontDestroyOnLoad(gameObject);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        if (previousSceneName == "Scene1" && scene.name == "Scene" && !puzleDestroyed)
        {
            Debug.Log("Transitioning from Scene 1 to Scene");
            // Do something when going from Scene 1 to Scene 2
            GameObject puzle = GameObject.FindGameObjectWithTag("puzle");
            if (puzle != null)
            {
                Destroy(puzle);
                puzleDestroyed = true;
                Debug.Log("Destroyed puzle");
            }
        }
        else if (previousSceneName == "Scene2" && scene.name == "Scene" && !puzzleDestroyed)
        {
            Debug.Log("Transitioning from Scene 2 to Scene");
            // Do something when going from Scene 3 to Scene 4
            GameObject puzzle = GameObject.FindGameObjectWithTag("puzzle");
            if (puzzle != null)
            {
                Destroy(puzzle);
                puzzleDestroyed = true;
                Debug.Log("Destroyed puzzle");
            }
        }

        previousSceneName = scene.name; // Update the previous scene name
    }
}
