using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerButtonPress : MonoBehaviour {
    private SteamVR_TrackedController device;

    // Use this for initialization
    void Start () {

        device = GetComponent<SteamVR_TrackedController>();
        device.TriggerClicked += Restart;

	}
	
    void Restart(object sander, ClickedEventArgs e)
    {
        Debug.Log("Click");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
