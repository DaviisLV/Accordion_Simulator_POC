using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObj : MonoBehaviour {

    private Valve.VR.EVRButtonId _triger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }
    private SteamVR_TrackedObject trackedObj;

    private GameObject obj;
    private FixedJoint fJoint;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        fJoint = GetComponent<FixedJoint>();
    }

    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (controller.GetPressDown(_triger))
        {
            PickUpObj();
        }

        if (controller.GetPressUp(_triger))
        {
            DropObj();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            obj = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        obj = null;
    }

    void PickUpObj()
    {
        if (obj != null)
        {
            fJoint.connectedBody = obj.GetComponent<Rigidbody>();
        }
        else
        {
            fJoint.connectedBody = null;
        }
    }

    void DropObj()
    {
        if (fJoint.connectedBody != null)
        {
            fJoint.connectedBody = null;
        }
    }
}
