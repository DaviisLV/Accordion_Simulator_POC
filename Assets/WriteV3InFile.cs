﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class WriteV3InFile : MonoBehaviour {

    public AudioSource Song;
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
   
    void OnApplicationQuit()
    {
        StopRecord();
    }

    public void StopRecord()
    {
        sr.Close();
        _isRecording = false;
        Song.Stop();
        Debug.Log("Stop");
    }
    public void StartRecord()
    {
        StartCoroutine(Record());
        Song.Play();
        Debug.Log("Start");
    }
}
