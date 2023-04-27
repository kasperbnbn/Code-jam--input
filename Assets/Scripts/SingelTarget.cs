using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingelTarget : MonoBehaviour
{
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Scene")
        {
            GameObject[] puzzleObjects = GameObject.FindGameObjectsWithTag("puzzle");
            foreach (GameObject puzzleObject in puzzleObjects)
            {
                Destroy(puzzleObject);
            }
        }
    }
}