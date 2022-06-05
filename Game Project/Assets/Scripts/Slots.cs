using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;


public class Slots : MonoBehaviour
{   public void QuitGame()
    {
        PlayerPrefs.SetInt("SlotSaved" + SaveID.saveID, 5);
        PlayerPrefs.SetInt("LoadSaved" + SaveID.saveID , 5);
        PlayerPrefs.SetInt("SavedScene" + SaveID.saveID, SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(6);
    }


    
}
