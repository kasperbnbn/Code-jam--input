using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.AudioSettings;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Windows;

public class MobileKeyboard : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;

    private void Start()
    {
        // Open the default keyboard type
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    private void Update()
    {
        if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
        {
            // User has finished entering text
            string input = keyboard.text;
            Debug.Log("Input: " + input);

            // Hide the keyboard
            keyboard.active = false;
            keyboard = null;
        }
    }
}

