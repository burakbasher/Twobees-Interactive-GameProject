using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;


public class ScreenSwitchButtons : MonoBehaviour
{
    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("SlotSaved" + SaveID.saveID, 1);
        PlayerPrefs.SetInt("LoadSaved" + SaveID.saveID , 1);
        PlayerPrefs.SetInt("SavedScene" + SaveID.saveID, SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenu");
    }


    
}
