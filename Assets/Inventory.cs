using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
public class Inventory : MonoBehaviour
{

    public GameObject username;
    public GameObject password;
    public GameObject login;


    public GameObject home, screen2;
    // Start is called before the first frame update

    public Text messagestatus;
    public Button btnlogin;

    private string Username;
    string Password;


    public class UserDetail
    {
        public string msg;
        // public int status;
        public Status status;
        public LoginData loginData;

    }

    [SerializeField]
    public class LoginData
    {
        public string email;
    }
    public class Status
    {
        public int code { get; set; }
        public string msg { get; set; }
    }


    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        btnlogin = login.GetComponent<Button>();
        btnlogin.onClick.AddListener(ValidateLogin);
    }

    // Update is called once per frame
    void Update()
    {
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;



    }


    private void ValidateLogin()
    {
        if (Username != "" & Password != "")
        {
            StartCoroutine(callLogin(Username, Password));
        }
        else
        {

        }
    }




    public IEnumerator callLogin(string Username, string Password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", Username);
        form.AddField("password", Password);

        Debug.Log(Username);
        Debug.Log(Password);


        // { "logindata":{ "email":"yuvaraj.ravi@in.ebmpapst.com","password":"jaravuy2019"} }

        //  { \"email\":" + Username + ", \"password\":" + Password + "} 

        var bodyJsonString = " { \"logindata\":{ \"email\":\"" + Username + "\", \"password\":\"" + Password + "\"}  } ";
        Debug.Log(bodyJsonString);

        var request = new UnityWebRequest("https://mynxg-service-layer.myomegasys.com/api/v3/data/?tid=06001100618220000K8R3G500-PW99-05&last=1", "GET");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.responseCode == 200)
        {
            Debug.Log("Status Code: " + request.responseCode);
            var msg = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);
            messagestatus.text = msg.status.msg;
            Debug.Log(messagestatus);
            home.SetActive(false);
            screen2.SetActive(true);










        }
        else
        {
            Debug.Log("Wrong Password");
            var msg = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);
            messagestatus.text = msg.status.msg;

        }



    }



}
