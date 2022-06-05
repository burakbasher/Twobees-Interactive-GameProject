using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterDesing : MonoBehaviour
{

    public string baseUrl = "http://localhost/gameprojectdb/CharecterDesing.php";
    
    public TMP_InputField playerName;
    public TMP_InputField playerLastName;
    public TMP_InputField playerAge;

    public TMP_Dropdown playerNation;

    public TMP_Dropdown playerClub;


    public void CharacterRegister()
    {
        string name = playerName.text;
        string lastname = playerLastName.text;
        string age = playerAge.text;
        string nation = playerNation.options[playerNation.value].text;
        string club = playerClub.options[playerClub.value].text;
        
        StartCoroutine(RegisterPlayer(name, lastname, age, nation, club));

        SceneManager.LoadScene(6);
         Debug.Log("Loading scene 6");
        
    }
    
    IEnumerator RegisterPlayer(string name, string lastname, string age, string nation, string club)
    {
        WWWForm form = new WWWForm();
        form.AddField("newplayerName", name);
        form.AddField("newplayerLastName", lastname);
        form.AddField("newplayerAge", age);
        form.AddField("newplayerNation", nation);
        form.AddField("newplayerClub", club);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gameprojectdb/CharacterDesing.php", form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
  
            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Response = " + responseText);
                
            }
        }
    }

    IEnumerator LoginPlayers(string name, string lastname, string age, string nation, string club)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginplayerName", name);
        form.AddField("loginplayerLastName", lastname);
        form.AddField("loginplayerAge", age);
        form.AddField("loginplayerNation", nation);
        form.AddField("loginplayerClub", club);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gameprojectdb/CharecterDesing.php", form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
            
  
            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                
                
                /*if(zort == 1 ){
                    PlayerPrefs.SetString(ukey, username);
                    info.text = "Login Success with username " + username;
                    Debug.Log("Login Success with username " + username);

                    SceneManager.LoadScene(1);
                }else{
                    info.text = "Login Failed." + zort;
                    
                    
                }*/
            }
        }
    }


}
