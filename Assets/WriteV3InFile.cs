using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class WriteV3InFile : MonoBehaviour {

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

        if (File.Exists(fileName))
        Debug.Log(fileName + " already exists and will be owerrite.");

        FileStream fcreate = File.Open(fileName, FileMode.Create);
        sr = new StreamWriter(fcreate);
            
        StartCoroutine(Record());

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StopRecord();
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
        return String.Format("{0:F4},{1:F4},{2:F4},", Controller.position.x, Controller.position.y, Controller.position.z);
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
