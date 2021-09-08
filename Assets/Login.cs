using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

using System.Threading.Tasks;
using System.Net;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class Login : MonoBehaviour
{

    public GameObject username;
    public GameObject password;
    public GameObject login;


    public GameObject home, screen2;
    // Start is called before the first frame update

    public  Text messagestatus;


    public Text speed;
    public Button btnlogin;


    public static string z;
    private string Username;
    string Password;

    public string token;



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
        if(Username !="" & Password !="")
        {
            StartCoroutine(callLogin(Username,Password));
        } else
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

        var request = new UnityWebRequest("https://mynxg-service-layer.myomegasys.com/api/v3/authentication/login/", "POST");
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

            z  =  messagestatus.text;

            //  Debug.Log(z);

            //messagestatus.text = az.ToString();

          //  var token = msg.logindata.authorization;


          SceneManager.LoadScene("mus");


            token = "Basic eXV2YXJhai5yYXZpQGluLmVibXBhcHN0LmNvbTpqYXJhdnV5MjAxOQ==";
            Debug.Log(token);
            Debug.Log("ENTER API");





            //HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(String.Format("https://mynxg-service-layer.myomegasys.com/api/v3/data/?tid=06001100618220000K8R3G500-PW99-05&last=1", token));
            //HttpWebResponse response = (HttpWebResponse)request2.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream());
            //string jsonResponse = reader.ReadToEnd();
            //Root info = JsonUtility.FromJson<Root>(jsonResponse);
            //yield return info;










            //    deviceRequest.GetResponseHeader(token);
            //    Debug.Log(deviceRequest.responseCode);
            //    Debug.Log(deviceRequest.result);

            //using (HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse())
            //using (Stream stream = response.GetResponseStream())
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    rt = reader.ReadToEnd();
            //    JObject data = JObject.Parse(rt);
            //    JToken token = (data["rows"][0]);
            //    return token;
            //}
























            var deviceRequest = new UnityWebRequest("https://mynxg-service-layer.myomegasys.com/api/v3/data/?tid=06001100618220000K8R3G500-PW99-05&last=1", "Get");

            deviceRequest.SetRequestHeader("Authorization", token);

            deviceRequest.GetRequestHeader(token);
            Debug.Log(deviceRequest.GetRequestHeader(token));


            deviceRequest.SetRequestHeader("Content-Type", "application/json");


            deviceRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            Debug.Log(deviceRequest.ToString());

            //var msg2 = JsonConvert.DeserializeObject<Roots>(deviceRequest.downloadHandler.text);
            //Debug.Log(msg2);

            yield return deviceRequest.SendWebRequest();

            deviceRequest.GetResponseHeader(token);
            Debug.Log(deviceRequest.responseCode);
            Debug.Log(deviceRequest.result);









            //var msg2 = JsonConvert.DeserializeObject<Data>(request2.downloadHandler.text);
            //speed.text = msg2.D010.u;
            //Debug.Log(speed);



            //var msg3 = JsonConvert.DeserializeObject<Root>(request2.downloadHandler.text);
            //Debug.Log(msg3.data[0].data.D010.u);
            //speed.text = msg3.data[0].data.D010.u;
            //Debug.Log(speed);


            //var msg4 = JsonConvert.DeserializeObject<D010>(request2.downloadHandler.text);
            //speed.text = msg4.u;
            //Debug.Log(speed);


            //az = Convert.ToInt32(msg2.D010.v);
            //speed.text = az.ToString();
            //Debug.Log(speed);





            //  home.SetActive(false);
            // screen2.SetActive(true);

            //if(request2.responseCode == 200)
            //{  
            //Debug.Log("Status: " + request2.responseCode);

            //}





        }
        else
        {
            Debug.Log("Wrong Password");
            var msg = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);
            messagestatus.text = msg.status.msg;

        }



}



}
