using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLoginSignUp()
    {
        SceneManager.LoadScene(0); 
    }
    public void LoadLogin()
    {
        SceneManager.LoadScene(1); 
    }
    public void LoadSignUp()
    {
        SceneManager.LoadScene(2); 
    }
     public void LoadMenu()
    {
        SceneManager.LoadScene(3); 
    }
    public void LoadCharacterDesign()
    {
        SceneManager.LoadScene(4); 
    }
    
    public void QuitGame ()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
}
