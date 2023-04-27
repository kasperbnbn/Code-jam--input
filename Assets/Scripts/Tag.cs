using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag : MonoBehaviour
{
    void Start()
    {
        Destroy(GameObject.FindGameObjectWithTag("puzzle"));
        Destroy(GameObject.FindGameObjectWithTag("puzle"));
        DontDestroyOnLoad(gameObject);
    }
}
