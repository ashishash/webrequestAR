using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCall : MonoBehaviour
{
    public string email;
    public string subject;
    public string body;
    public void makePhoneCall()
    {
        Application.OpenURL("tel://+910000000000");
        Debug.Log("tsting");
    }

   public  void SendEmail()
    {
    
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }


    public void Open360()
    {
#if PLATFORM_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.epm.entrypoint&hl=en_IN&gl=US");
#else
        Application.OpenURL("https://apps.apple.com/in/app/ebm-papst-360/id1437906759");
#endif

    }
}
