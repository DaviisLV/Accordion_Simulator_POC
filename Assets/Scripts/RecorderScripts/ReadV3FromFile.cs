using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadV3FromFile : MonoBehaviour {
     public Transform items;

    public List<Vector3> points = new List<Vector3>();
    Vector3[] allPoints;


    private void Awake()
    {

       allPoints = points.ToArray();
    }

  
    private void Start()
    {
       
        for (int  f = 0; f <= allPoints.Length; f++)
        {
           
            Transform item = Instantiate(items) as Transform;
            Vector3 position = allPoints[f];
            item.transform.localPosition = position;
              
            }
        }
    }


