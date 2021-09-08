using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotw : MonoBehaviour
{
    public GameObject cube1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cube1.transform.Rotate(5000.0f * Time.deltaTime, 0.0f, 0.0f, Space.Self);
    }
}
