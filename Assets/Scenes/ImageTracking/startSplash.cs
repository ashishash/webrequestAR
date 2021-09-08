using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSplash : MonoBehaviour
{
    public GameObject  Psearching,Panimation, Precording, mainMenuP, mainMenuL;
    public GameObject cameraW,cameraD;
    bool isStarted =false, clicked = false;
    public bool startRecord = false;

    public GameObject recordTxt, artnameTxt;
    

    public UIAnimation animationScript;
    // Start is called before the first frame update

    public void gotoRecording(){

            recordTxt.SetActive(true);
            artnameTxt.SetActive(false);
        cameraD.SetActive(true);
        cameraW.SetActive(false);
        Panimation.SetActive(false);
        Precording.SetActive(true);
        startRecord = true;
        animationScript.StartAnimation();
    }

public void closeRecording(){
     Screen.orientation = ScreenOrientation.Portrait;

    recordTxt.SetActive(false);
            artnameTxt.SetActive(true);
   
    mainMenuP.SetActive(true);
   // mainMenuL.SetActive(false);
    cameraD.SetActive(false);
        cameraW.SetActive(true);
        Panimation.SetActive(true);
        Precording.SetActive(false);
        animationScript.flag4 = true;
        animationScript.redIcon.SetActive(false);
        animationScript.Rectangle.SetActive(false);
         animationScript. Polygon.SetActive(false);
           animationScript.share.SetActive(false);
            animationScript.Trash.SetActive(false);
    }

    void Start()
    {
        if(isStarted == false){
      //  StartCoroutine(startSearching());
        isStarted = true;
        }
    }


//    IEnumerator startSplashS(){
//        yield return new WaitForSeconds(2);
//        Psplash.SetActive(false);
//        StartCoroutine(startSearching());
//        StopCoroutine(startSplashS());
       
//    }

   IEnumerator startSearching(){
       yield return new WaitForSeconds(2);
      Psearching.SetActive(false);
      Panimation.SetActive(true);
       StopCoroutine(startSearching());
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}//class
