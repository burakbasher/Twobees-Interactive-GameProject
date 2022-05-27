using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayNewGame ()
    {
        SceneManager.LoadScene(1); //1. sahne yeni oyun
    }
    
    public void QuitGame ()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
}
