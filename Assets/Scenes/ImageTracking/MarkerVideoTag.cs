using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerVideoTag : MonoBehaviour
{
    Vector3 testPos, videoPos, newScale, testButPos,butPos,rot,MovPos,butMovPos, OriginalScale, ButOriRot;
    public GameObject testVid,vid, but,testBut,MovBut;
    public GameObject Vid2,vid22, vid2Final, txtPlay,txtStory, butStory, butPlay;
    Vector3 vid2Pos, vid2OrigPos, butPosStory,butPosPlay;
    float speed = 3.8f, speed2 = 5f;
    public bool markerFound;
    // Start is called before the first frame update
    void Start()
    {
        testButPos = testBut.transform.position;
        butPos = but.transform.position;
        rot = testBut.transform.eulerAngles; 
        ButOriRot = but.transform.eulerAngles; 

        //MovPos = MovVid.transform.position;

        butMovPos = MovBut.transform.position;

        testPos = testVid.transform.position;
        videoPos = vid.transform.position;
        newScale = testVid.transform.localScale;
        OriginalScale = vid.transform.localScale;

        vid2Pos = vid2Final.transform.position; 
        vid2OrigPos = Vid2.transform.position;

        butPosStory = butStory.transform.position;
        butPosPlay = butPlay.transform.position;
        
    //      vid.SetActive(true);
    //      StartCoroutine("startA");
    //    StartCoroutine("startB");
      
    //   flag = true;
        
    }

bool flag,flag2,flag3, flag4;
      IEnumerator startA(){
        yield return new WaitForSeconds(2.5f);
        
        flag = false;
        flag2 = false;
        flag3 = false;
       flag4 = false;
        
        StopCoroutine("startA");

    }
    IEnumerator startAo(){
        yield return new WaitForSeconds(0.1f);
        
      //  txtPlay.SetActive(false);
       txtStory.SetActive(true);
       StartCoroutine("startAoo");
        
        StopCoroutine("startAo");

    }
      IEnumerator startAoo(){
        yield return new WaitForSeconds(0.1f);
        
        txtPlay.SetActive(true);
      // txtStory.SetActive(true);
        
        StopCoroutine("startAoo");

    }

    IEnumerator startB(){
        yield return new WaitForSeconds(0.2f);
        but.SetActive(true);
        flag5 = false;
        
        flag2 = true;
        StartCoroutine("startC");
        
        StopCoroutine("startB");

    }
     IEnumerator startC(){
        yield return new WaitForSeconds(0.2f);
       
        
        flag3 = true;
        StartCoroutine("startD");
        StopCoroutine("startC");

    }

     IEnumerator startD(){
        yield return new WaitForSeconds(1.5f);
       txtPlay.SetActive(false);
       txtStory.SetActive(false);
        
        flag = false;
        flag2 = false;
        flag3 = false;
        flag4 = true;
        Vid2.SetActive(true);
        vid22.SetActive(true);
        vid.SetActive(false);
        
        StopCoroutine("startD");

    }

    IEnumerator startE(){
        yield return new WaitForSeconds(0.1f);
       
        flag5 = true;
      
        
        StopCoroutine("startE");

    }
    IEnumerator startF(){
        yield return new WaitForSeconds(2f);
       
        markerStart();
      
        
        StopCoroutine("startF");

    }

    public void markerStart(){
        vid.SetActive(true);
         StartCoroutine("startA");
        StartCoroutine("startB");
        flag = true;

        
    }

    public void markerStop(){
        vid.SetActive(false);
             but.SetActive(false);
             Vid2.SetActive(false);
             vid22.SetActive(false);
              but.transform.position=butPos ;
        
            but.transform.eulerAngles= ButOriRot ; 
        

        
                vid.transform.position=videoPos ;
       
                 vid.transform.localScale=OriginalScale ;
    }

    public GameObject buttonP;
    bool flag5;
    public void buttonPlay(){
        //buttonP.SetActive(false);
        flag4 = false;
        StartCoroutine("startE");

    }

    public void buttonStop(){
        //buttonP.SetActive(true);
        flag5 = false;
        flag4 = true;
        // StartCoroutine("startD");

    }
    // Update is called once per frame
    void Update()
    {

        if(markerFound==true){
            StartCoroutine("startF");
        //         vid.SetActive(true);
                 
        //  StartCoroutine("startA");
        // StartCoroutine("startB");
        // flag = true;
        markerFound = false;
        }else{
            //  vid.SetActive(false);
            //  but.SetActive(false);
            //   but.transform.position=butPos ;
        
            // but.transform.eulerAngles= ButOriRot ; 
        

        
            //     vid.transform.position=videoPos ;
       
            //      vid.transform.localScale=OriginalScale ;
        }

        if(flag == true){
        vid.transform.position = Vector3.Lerp(vid.transform.position,testPos, Time.deltaTime*speed);
        vid.transform.localScale = Vector3.Lerp(vid.transform.localScale,newScale, Time.deltaTime*speed);
        //but.transform.eulerAngles = Vector3.Lerp(but.transform.eulerAngles, rot , Time.deltaTime*speed );
        }

         if(flag2 == true){
        but.transform.position = Vector3.Lerp(but.transform.position,testButPos, Time.deltaTime*speed2);
     //  but.transform.eulerAngles = Vector3.Lerp(but.transform.eulerAngles, rot , Time.deltaTime*speed2 );
        }
          if(flag3 == true){
       // but.transform.position = Vector3.Lerp(but.transform.position,testButPos, Time.deltaTime*speed2);
        but.transform.eulerAngles = Vector3.Lerp(but.transform.eulerAngles, rot , Time.deltaTime*10 );
        }

        if(flag4 == true){
        but.transform.position = Vector3.Lerp(but.transform.position,butMovPos, Time.deltaTime*10);
        Vid2.transform.position = Vector3.Lerp(Vid2.transform.position, vid2Pos , Time.deltaTime*10 );
        }

        if(flag5 == true){
        but.transform.position = Vector3.Lerp(but.transform.position,testButPos, Time.deltaTime*10);
        Vid2.transform.position = Vector3.Lerp(Vid2.transform.position, vid2OrigPos , Time.deltaTime*10 );
        }

        if(but.transform.position.x < butPlay.transform.position.x){
        txtPlay.SetActive(true);
     //  txtStory.SetActive(false);
        }else{
            txtPlay.SetActive(false);
        }
        if(but.transform.position.x <butStory.transform.position.x){
        //txtPlay.SetActive(true);
       txtStory.SetActive(true);
        }else{
            txtStory.SetActive(false);
        }

       // Debug.Log("story "+butStory.transform.position);
        //Debug.Log("play "+butPlay.transform.position);
       // Debug.Log(but.transform.position.x);


    }
}//class
