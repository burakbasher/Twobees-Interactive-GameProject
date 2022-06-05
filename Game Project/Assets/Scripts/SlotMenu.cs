using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class SlotMenu : MonoBehaviour
{
    public GameObject[] newGameButtons = new GameObject[3];
    public GameObject[] loadGameButtons = new GameObject[3];

    public int[] saveIDs = new int[3];
    private void Update()
    {
        
        if(PlayerPrefs.GetInt("SlotSaved" + saveIDs[0]) == 5)
        {
            loadGameButtons[0].SetActive(true);
            newGameButtons[0].SetActive(false);
        }
        else
        {
            loadGameButtons[0].SetActive(false);
            newGameButtons[0].SetActive(true);
        }
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene(6);
       
    }
    public void LoadGame()
    {
        if(PlayerPrefs.GetInt("LoadSaved" + SaveID.saveID) == 5)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene" + SaveID.saveID));
        }
        else
        {
            return;
        }
    }
    public void SetSaveID(int saveID)
    {
        SaveID.saveID = saveID;
    }
    public void ClearSave(int saveID)
    {
        /*PlayerPrefs.DeleteKey("SlotSaved" + saveID);*/
        PlayerPrefs.DeleteAll();
        
    }

    public void Quit()
    {
        PlayerPrefs.SetInt("LoadSaved",5);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(3);
    }
}
