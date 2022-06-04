using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] newGameButtons = new GameObject[3];
    public GameObject[] loadGameButtons = new GameObject[3];

    public int[] saveIDs = new int[3];
    private void update()
    {
        
        if(PlayerPrefs.GetInt("SlotSaved" + saveIDs[0]) == 1)
        {
            loadGameButtons[0].SetActive(true);
            newGameButtons[0].SetActive(false);
        }
        else
        {
            loadGameButtons[0].SetActive(false);
            newGameButtons[0].SetActive(true);
        }
        
        if(PlayerPrefs.GetInt("SlotSaved" + saveIDs[0]) == 1)
        {
            loadGameButtons[1].SetActive(true);
            newGameButtons[1].SetActive(false);
        }
        else
        {
            loadGameButtons[1].SetActive(false);
            newGameButtons[1].SetActive(true);
        }
        
        if(PlayerPrefs.GetInt("SlotSaved" + saveIDs[0]) == 1)
        {
            loadGameButtons[2].SetActive(true);
            newGameButtons[2].SetActive(false);
        }
        else
        {
            loadGameButtons[2].SetActive(false);
            newGameButtons[2].SetActive(true);
        }
    }
    public void LoadLoginSignUp()
    {
        SceneManager.LoadScene(0); 
        Debug.Log("Loading scene 0, LoginSignUp Scene");
    }
    public void LoadLogin()
    {
        SceneManager.LoadScene(1); 
         Debug.Log("Loading scene 1, Login Scene");
    }
    public void LoadSignUp()
    {
        SceneManager.LoadScene(2); 
         Debug.Log("Loading scene 2, SignUp Scene");
    }
     public void LoadMenu()
    {
        SceneManager.LoadScene(3);
         Debug.Log("Loading scene 3, Menu Scene");
    }
    public void LoadCharacterDesign()
    {
        SceneManager.LoadScene(4);
         Debug.Log("Loading scene 4, CharacterDesign Scene");
    }
    public void LoadBoss()
    {
        SceneManager.LoadScene(5);
         Debug.Log("Loading scene 5, Boss Scene");
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(6);
         Debug.Log("Loading scene 6, Level1 Scene");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(7);
         Debug.Log("Loading scene 7, Level2 Scene");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(8);
         Debug.Log("Loading scene 8, Level3 Scene"); 
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(9);
         Debug.Log("Loading scene 9, Level4 Scene"); 
    }
    public void QuitLevel()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(3);
    }
    public void NewGame()
    {
        SceneManager.LoadScene(4);
       
    }
    public void LoadGame()
    {
        if(PlayerPrefs.GetInt("LoadSaved" + SaveID.saveID) == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
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
        PlayerPrefs.DeleteKey("SlotSaved" + saveID);
    }
    
    

}
