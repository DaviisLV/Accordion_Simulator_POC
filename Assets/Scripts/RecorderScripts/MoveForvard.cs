using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForvard : MonoBehaviour {
    public bool Start = false;

	void Update () {
		if ( Start == true)
        this.transform.position += Vector3.forward * Time.deltaTime * 2;
    }
}
