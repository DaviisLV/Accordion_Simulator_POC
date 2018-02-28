using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForvard : MonoBehaviour {
    public bool move = false;
  
    void Update () {
		if ( move == true)
        this.transform.position += Vector3.forward * Time.deltaTime * 2;
    }
}
