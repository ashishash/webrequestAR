using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{

    public GameObject baseback, light, redIcon, Rectangle, Trash, share,Polygon, testBase,testLight,testRed, testRedUp;
    Vector3 posBase,posLight, finalBase,finalLight, posRed, finalRed, initialRed;
    float speed = 4f;
    // Start is called before the first frame update
   public void StartAnimation()
    {
        // posBase = baseback.transform.position;
        // posLight = light.transform.position;
        // posRed = redIcon.transform.position;

        // finalBase = new Vector3(posBase.x,posBase.y+407.5f,0f);
        // finalLight = new Vector3(posLight.x,posLight.y+407.5f,0f);

        // initialRed = new Vector3(posRed.x,posRed.y+330f,0f);
        // finalRed = new Vector3(posRed.x,posRed.y+296.8f,0f);
        //Debug.Log("base "+ posBase );
       // Debug.Log("light "+posLight);
       //Debug.Log("Red "+posRed);
        flag4 = false;
        StartCoroutine("startUI");
         StartCoroutine("startRed");
         flag = true;
        

    }
    private void Start() {
        posBase = baseback.transform.position;
        posLight = light.transform.position;
        posRed = redIcon.transform.position;

        
        // finalBase = new Vector3(posBase.x,posBase.y+407.5f,0f);
        // finalLight = new Vector3(posLight.x,posLight.y+407.5f,0f);

        finalBase = testBase.transform.position;
        finalLight = testLight.transform.position;

      // initialRed = new Vector3(posRed.x,posRed.y+330f,0f);
                initialRed =  testRedUp.transform.position;
        // finalRed = new Vector3(posRed.x,posRed.y+296.8f,0f);
         finalRed = testRed.transform.position;
    }

    IEnumerator startRed(){
        yield return new WaitForSeconds(0.5f);
        redIcon.SetActive(true);
        flag2 = true;
          StartCoroutine("stopRed");
        StopCoroutine("startRed");

    }

     IEnumerator stopRed(){
        yield return new WaitForSeconds(0.5f);
        flag2 = false;
        flag3 = true;
        Rectangle.SetActive(true);
          Polygon.SetActive(true);
           share.SetActive(true);
            Trash.SetActive(true);
            StartCoroutine("EndAll");
        StopCoroutine("stopRed");

    }

    IEnumerator startUI(){
        yield return new WaitForSeconds(2f);
        
        flag = false;
        
        StopCoroutine("startUI");

    }

     IEnumerator EndAll(){
        yield return new WaitForSeconds(0.5f);
        
        flag = false;
      //  flag2 = false;
         flag3 = false;
         

        StopCoroutine("EndAll");

    }
    //Red (537.5, 305.6, 0.0)
    //light (537.1, 454.3, 0.0)
    //base (537.1, -225.1, 0.0)

    //baseD (537.1, -632.6, 0.0)
    //RedD (537.5, 8.8, 0.0)
    //lightD (537.1, 46.8, 0.0)
bool flag = false,flag2 = false, flag3 = false;
public bool  flag4;
    // Update is called once per frame
    void Update()
    {
        if(flag == true){
         baseback.transform.position = Vector3.Lerp(baseback.transform.position,finalBase, Time.deltaTime*speed);
          light.transform.position = Vector3.Lerp(light.transform.position,finalLight, Time.deltaTime*speed);
        }

         if(flag2 == true){
         redIcon.transform.position = Vector3.Lerp(redIcon.transform.position,initialRed, Time.deltaTime*10f);
           
       

         
        }

         if(flag3 == true){
         
         redIcon.transform.position = Vector3.Lerp(redIcon.transform.position,finalRed, Time.deltaTime*10f);
             
         
        }

        if(flag4 == true){
            baseback.transform.position = Vector3.Lerp(baseback.transform.position,posBase, Time.deltaTime*10f);
          light.transform.position = Vector3.Lerp(light.transform.position,posLight, Time.deltaTime*10f);
           redIcon.transform.position = Vector3.Lerp(redIcon.transform.position,posRed, Time.deltaTime*10f);
        }
    }
}
