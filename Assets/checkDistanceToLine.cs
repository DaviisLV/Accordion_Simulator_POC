using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDistanceToLine : MonoBehaviour {

    public BezierSpline spline;

    public float duration;

    private float progress;

    private void Update()
    {
        progress += Time.deltaTime / duration;
        if (progress > 1f)
        {
            progress = 1f;
        }
        
        Debug.Log(Vector3.Distance(this.transform.position, spline.GetPoint(progress)));
    }
}
