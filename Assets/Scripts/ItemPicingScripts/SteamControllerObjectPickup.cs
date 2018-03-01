﻿using UnityEngine;
using System.Collections;

public class SteamControllerObjectPickup : MonoBehaviour
{
    private const Valve.VR.EVRButtonId TriggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_TrackedObject _trackedObj;
    private FixedJoint _fixedJoint;

    private Rigidbody objectRigidbody;
    private GameObject pickedObject;
    private bool isThrowing;
    private bool isPicked = false;
    private bool isRuning = false;
    private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)_trackedObj.index); } }

    #region MonoBehaviour
    private void Start()
    {
        _trackedObj = GetComponent<SteamVR_TrackedObject>();

        _fixedJoint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        if (Controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)_trackedObj.index);

        if (Controller.GetPressDown(TriggerButton))
        {
            PickUpObj();
        }

        if (Controller.GetPressUp(TriggerButton))
        {
            DropObj();
        }
    }

    private void FixedUpdate()
    {
        if (isThrowing)
        {
            Transform origin;
            if (_trackedObj.origin != null)
            {
                origin = _trackedObj.origin;
            }
            else
            {
                origin = _trackedObj.transform.parent;
            }

            if (origin != null)
            {
                objectRigidbody.velocity = origin.TransformVector(Controller.velocity);
                objectRigidbody.angularVelocity = origin.TransformVector(Controller.angularVelocity * 0.25f);
            }
            else
            {
                objectRigidbody.velocity = Controller.velocity;
                objectRigidbody.angularVelocity = Controller.angularVelocity * 0.25f;
            }

            objectRigidbody.maxAngularVelocity = objectRigidbody.angularVelocity.magnitude;

            isThrowing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Pickable>())
        {
            pickedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickedObject = null;
    }
    #endregion

    private void PickUpObj()
    {
        if (pickedObject != null)
        {
            isPicked = true;
            _fixedJoint.connectedBody = pickedObject.GetComponent<Rigidbody>();
            pickedObject.GetComponent<Rigidbody>().useGravity = false;
            pickedObject.GetComponent<Rigidbody>().freezeRotation = false;
            pickedObject.transform.position = Vector3.zero;
            pickedObject.transform.rotation = Quaternion.identity;
            objectRigidbody = null;
            if (!isRuning)
            {
                StartCoroutine(RePosition());
                isRuning = true;
            }
        }
        else
        {
            _fixedJoint.connectedBody = null;
        }
    }

    private void DropObj()
    {
        if (_fixedJoint.connectedBody != null)
        {
            isPicked = false;
            isRuning = false;
            objectRigidbody = _fixedJoint.connectedBody;
            pickedObject.GetComponent<Rigidbody>().rotation = Quaternion.identity;
            pickedObject.GetComponent<Rigidbody>().useGravity = true;
            pickedObject.GetComponent<Rigidbody>().freezeRotation = true;
            _fixedJoint.connectedBody = null;

            isThrowing = true;

        }
    }
    IEnumerator RePosition()
    {
        while (isPicked)
        {
            Debug.Log("Runing");
        }
        return null;
    }

}