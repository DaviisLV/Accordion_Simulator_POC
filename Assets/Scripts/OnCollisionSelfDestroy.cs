using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSelfDestroy : MonoBehaviour {
    int caunt;

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag =="Cube")

        Destroy(other.gameObject);
        caunt++;
        Debug.Log(caunt);
    }

  public int GetHitCount()
    {
        return caunt;
    }

}
