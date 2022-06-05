using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
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
    public void LoadSlots()
    {
        SceneManager.LoadScene(4);
         Debug.Log("Loading scene 4, Slots Scene");
    }
    public void LoadCharacterDesign()
    {
        SceneManager.LoadScene(5);
         Debug.Log("Loading scene 5, Character Scene");
    }
    public void LoadBoss()
    {
        SceneManager.LoadScene(6);
         Debug.Log("Loading scene 6, Boss Scene");
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(7);
         Debug.Log("Loading scene 6, Level1 Scene");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(8);
         Debug.Log("Loading scene 7, Level2 Scene");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(9);
         Debug.Log("Loading scene 8, Level3 Scene"); 
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(10);
         Debug.Log("Loading scene 9, Level4 Scene"); 
    }
    public void QuitLevel()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(3);
    }

}
