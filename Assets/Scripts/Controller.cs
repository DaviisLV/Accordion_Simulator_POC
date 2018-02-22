using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject HeadCamera;
    public GameObject Accardion;



    // Use this for initialization
    void Start()
    {
        Accardion.transform.position = new Vector3(HeadCamera.transform.position.x, HeadCamera.transform.position.y - 1, HeadCamera.transform.position.z + 0.3f);
    }


        // Update is called once per frame
        void Update () {
        this.gameObject.transform.position = HeadCamera.transform.position;

      
    }
}
