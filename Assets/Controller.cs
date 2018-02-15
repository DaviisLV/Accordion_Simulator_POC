using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject LeftConttroler;
    public GameObject RighrtConntroler;
    public GameObject HeadCamera;
    public GameObject boxPrefab;
    private GameObject box;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("test");
            box = Instantiate(boxPrefab);
            box.transform.position = new Vector3(HeadCamera.transform.position.x + (0.5f * i), HeadCamera.transform.position.y - 0.4f, HeadCamera.transform.position.z + 0.5f);



        }
    }


        // Update is called once per frame
        void Update () {
        float dist = Vector3.Distance(LeftConttroler.transform.position, RighrtConntroler.transform.position);
        //Debug.Log(dist);
    }
}
