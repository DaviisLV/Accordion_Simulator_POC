using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class WriteV3InFile : MonoBehaviour {

    public AudioSource Audio;
    public Transform Controller;
    public string FileName;
    string fileName;
    private bool _isRecording = true;
    private bool _isStarted = false;
    [Range(0.001f, 2f)]
    public float speed;
    StreamWriter sr;

    public void Awake()
    {
        fileName = FileName + Controller.name + ".txt";
    }

    public void StopRecord()
    {
        if (!_isStarted) return;
        sr.Close();
        _isRecording = false;
        Audio.Stop();
        Debug.Log("Stop");
    }

    public void StartRecord()
    {
        if (File.Exists(fileName))
            Debug.Log(fileName + " already exists and will be owerrite.");

        FileStream fcreate = File.Open(fileName, FileMode.Create);
        sr = new StreamWriter(fcreate);
        StartCoroutine(Record(speed));
        Audio.Play();
        _isStarted = true;
        Debug.Log("Start");
    }

    public IEnumerator Record(float speed)
    {

        while (_isRecording)
        {
            sr.WriteLine(GetV3Position());
            yield return new WaitForSeconds(speed);
        }
  
    }
    string GetV3Position()
    {
        Debug.Log(Controller.position);
        Debug.Log(Controller.localPosition);
        Debug.Log(Controller.TransformPoint(Vector3.zero));
        return String.Format("{0:F4},{1:F4},{2:F4}", Controller.position.x, Controller.position.y, Controller.position.z);
    }
   
    void OnApplicationQuit()
    {
        StopRecord();
    }
}
