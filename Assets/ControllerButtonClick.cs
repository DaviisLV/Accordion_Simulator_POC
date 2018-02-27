﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerButtonClick : MonoBehaviour {

    public WriteV3InFile file;

    private const Valve.VR.EVRButtonId Menu = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
    private const Valve.VR.EVRButtonId Triger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_TrackedObject _trackedObj;
    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)_trackedObj.index); } }

    private void Start()
    {
        _trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    private void Update()
    {
        if (Controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        if (Controller.GetPressDown(Menu))
        {
            
           file.StartRecord();    

        }

        if (Controller.GetPressDown(Triger))
        {
           
            file.StopRecord();

        }
    }


}


