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

    public TMP_Text info;


    
    
    IEnumerator CharacterInfos(string name, string lastname, string age, string nation, string club)
    {
        WWWForm form = new WWWForm();
        form.AddField("newplayerName", name);
        form.AddField("newplayerLastName", lastname);
        form.AddField("newplayerAge", age);
        form.AddField("newplayerNation", nation);
        form.AddField("newplayerClub", club);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
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
                info.text = "Response = " + responseText;
            }
        }
    }


}
