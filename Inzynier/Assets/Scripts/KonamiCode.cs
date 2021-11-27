using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KonamiCode : MonoBehaviour
{
    private List<string> keyStrokeHistory;

    void Awake()
    {
        keyStrokeHistory = new List<string>();
    }

    void Update()
    {
        KeyCode keyPressed = DetectKeyPressed();
        AddKeyStrokeToHistory(keyPressed.ToString());
        if(GetKeyStrokeHistory().Equals("UpArrow,UpArrow,DownArrow,DownArrow,LeftArrow,RightArrow,LeftArrow,RightArrow,B,A")) 
        {
            AchievmentsManager.achievmentsManagerInstance.addAchievmentProgress("11",1);
            ClearKeyStrokeHistory();
        }

    }

    private KeyCode DetectKeyPressed()
    {
        foreach(KeyCode key in Enum.GetValues(typeof(KeyCode))) 
        {
            if(Input.GetKeyDown(key)) return key;
        }
        return KeyCode.None;
    }

    private void AddKeyStrokeToHistory(string keyStroke)
    {
        if(!keyStroke.Equals("None")) {
            keyStrokeHistory.Add(keyStroke);
            if(keyStrokeHistory.Count > 10) {
                keyStrokeHistory.RemoveAt(0);
            }
        }
    }

    private string GetKeyStrokeHistory() {
        return String.Join(",", keyStrokeHistory.ToArray());
    }

    private void ClearKeyStrokeHistory() 
    {
        keyStrokeHistory.Clear();
    }
}
