using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAssChild : MonoBehaviour {

    public Transform accardion;

	// Use this for initialization
	void Start () {

        accardion.SetParent(this.gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
