using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    public Button[] Buttons; 

    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel",7);

        for(int i = 0; i < Buttons.Length; i++)
        {
            if(i + 7 > currentLevel)
            {
               
                Buttons[i].interactable = false;
                    
            }               
        }
    }   
}
