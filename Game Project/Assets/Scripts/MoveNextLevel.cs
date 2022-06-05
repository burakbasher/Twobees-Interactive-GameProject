using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class MoveNextLevel : MonoBehaviour
{
    
    public int LoadNext;
    // Start is called before the first frame update
    void Start()
    {
        LoadNext = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D a)
    {
        if(a.tag == "EndPoint") 
        {
            if(SceneManager.GetActiveScene().buildIndex == 10)
            {
                Debug.Log("You win the game");
            }
            SceneManager.LoadScene(LoadNext);

            if(LoadNext > PlayerPrefs.GetInt("currentLevel"))
            {
                PlayerPrefs.SetInt("currentLevel", LoadNext);
            }
        }
    }
}
