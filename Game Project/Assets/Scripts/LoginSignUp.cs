using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginSignUp : MonoBehaviour
{
     
    public string baseUrl = "http://localhost/gameprojectdb/LoginSignUp.php";
     
     
    public TMP_InputField accountUserName;
    public TMP_InputField accountPassword;
    public TMP_Text info;
     
    private string currentUsername;
    private string ukey = "accountusername";
     
    // Start is called before the first frame update
    void Start()
    {
        currentUsername = "";
         
        if(PlayerPrefs.HasKey(ukey)){
            if(PlayerPrefs.GetString(ukey) != ""){
                currentUsername = PlayerPrefs.GetString(ukey);
                info.text = "You are loged in = " + currentUsername;
            }else{
                info.text = "You are not loged in.";
            }
        }else{
            info.text = "You are not loged in.";
        }
         
    }
 
    // Update is called once per frame
    void Update()
    {
         
    }
     
    public void AccountLogout(){
        currentUsername = "";
        PlayerPrefs.SetString(ukey, currentUsername);
        info.text = "You are just loged out.";
    }
     
    public void AccountRegister()
    {
        string username = accountUserName.text;
        string password = accountPassword.text;
        StartCoroutine(RegisterNewAccount(username, password));
    }
     
    public void AccountLogin()
    {
        string username = accountUserName.text;
        string password = accountPassword.text;
        StartCoroutine(LogInAccount(username, password));
       
    
        SceneManager.LoadScene(3);
         Debug.Log("Loading scene 3, Menu Scene");
    
        
    }
     
    IEnumerator RegisterNewAccount(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("newAccountUsername", username);
        form.AddField("newAccountPassword", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gameprojectdb/LoginSignUp.php", form))
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
     
    IEnumerator LogInAccount(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", username);
        form.AddField("loginPassword", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gameprojectdb/LoginSignUp.php", form))
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
                int conv = int.Parse(responseText);
                
                if(conv == 1 ){
                    PlayerPrefs.SetString(ukey, username);
                    info.text = "Login Success with username " + username;
                    Debug.Log("Login Success with username " + username);

                }else{
                    info.text = "Login Failed." + conv;
                    
                    
                }
            }
        }
    }
}
