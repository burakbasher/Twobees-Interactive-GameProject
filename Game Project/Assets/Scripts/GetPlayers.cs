using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;
public class GetPlayers : MonoBehaviour
{
    public TMP_Text info_name;
    public TMP_Text info_lastname;
    public TMP_Text info_nation;
    public TMP_Text info_club;


    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("http://localhost/gameprojectdb/card.php"));
    
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    string rawresponse = webRequest.downloadHandler.text;

                    string[] users = rawresponse.Split("*");

                   
                       if(users[0]!= "")
                        {
                            string[] userinfo = users[0].Split(",");
                            Debug.Log("Name: " + userinfo[0] + "Last name: " + userinfo[1] + "Nation: " + userinfo[2] + "Club: " + userinfo[3]);
                            info_name.text = userinfo[0];
                            info_lastname.text = userinfo[1];
                            info_nation.text = userinfo[2];
                            info_club.text = userinfo[3];
                        }
                    
                    break;
            }
        }
    }
}
