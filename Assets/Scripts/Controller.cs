using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject HeadCamera;



    // Use this for initialization
    void Start()
    {
    }


        // Update is called once per frame
        void Update () {
        this.gameObject.transform.position = HeadCamera.transform.position;

      
    }
}
