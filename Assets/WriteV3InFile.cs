using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class WriteV3InFile : MonoBehaviour {

    private const Valve.VR.EVRButtonId TriggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private const Valve.VR.EVRButtonId GripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    private SteamVR_TrackedObject _trackedObj;
    private SteamVR_Controller.Device Controllers { get { return SteamVR_Controller.Input((int)_trackedObj.index); } }


    public Transform Controller;
    public string FileName;
    string fileName;
    private bool _isRecording = true;
    [Range(0.001f, 2f)]
    public float speed;
    StreamWriter sr;
    public void Awake()
    {
        fileName = FileName + Controller.name + ".txt";
    }
    public void Start()
    {
         _trackedObj = GetComponent<SteamVR_TrackedObject>();

    }
    public void StartRecord()
    {
        if (File.Exists(fileName))
        Debug.Log(fileName + " already exists and will be owerrite.");

        FileStream fcreate = File.Open(fileName, FileMode.Create);
        sr = new StreamWriter(fcreate);
            
        StartCoroutine(Record());
    }

    private void Update()
    {

        if (Controllers.GetPressDown(TriggerButton))
        {
            StopRecord();
        }
        if (Controllers.GetPressDown(GripButton))
        {
            StartRecord();
        }
    }

    public IEnumerator Record()
    {

        while (_isRecording)
        {
            sr.WriteLine(GetV3Position());
            yield return new WaitForSeconds(speed);
        }
  
    }
    string GetV3Position()
    {
        return String.Format("{0:F4},{1:F4},{2:F4}", Controller.position.x, Controller.position.y, Controller.position.z);
    }
    public void StopRecord()
    {
        sr.Close();
        _isRecording = false;
        Debug.Log("Stop");
    }

    void OnApplicationQuit()
    {
        StopRecord();
    }
}
