using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn : MonoBehaviour
{
    public GameObject panel;
    public Text p1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        panel.SetActive(true);
        p1.text = Login.z;
        Debug.Log(p1);
      //  Debug.Log(Login.messagestatus);
        panel.SetActive(true);
    }
}
