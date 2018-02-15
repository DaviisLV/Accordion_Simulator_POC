using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject LeftConttroler;
    public GameObject RighrtConntroler;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(LeftConttroler.transform.position, RighrtConntroler.transform.position);
        Debug.Log(dist);
    }
}
