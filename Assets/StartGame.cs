using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject line1;
    //public GameObject line2;

    private const Valve.VR.EVRButtonId Start = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;

    private SteamVR_TrackedObject _trackedObj;
    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)_trackedObj.index); } }


    private void Update()
    {
        if (Controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        if (Controller.GetPressDown(Start))
        {

            line1.SetActive(true);
           // line2.SetActive(true);

        }
    }


    }
