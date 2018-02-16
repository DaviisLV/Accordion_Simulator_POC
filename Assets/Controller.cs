using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

  
    public GameObject HeadCamera;
    public GameObject PathHight;


    // Use this for initialization
    void Start()
    {
        PathHight.transform.position = new Vector3(PathHight.transform.position.x, HeadCamera.transform.position.y - 0.15f, PathHight.transform.position.z);
    }


        // Update is called once per frame
        void Update () {
      
    }
}
