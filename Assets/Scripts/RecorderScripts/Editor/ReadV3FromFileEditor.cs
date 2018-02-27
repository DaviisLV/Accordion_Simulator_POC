using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using System.IO;
using System.Globalization;

[CustomEditor(typeof(ReadV3FromFile))]
public class ReadV3FromFileEditor : Editor
{
    public string filePath;
    private ReadV3FromFile rf;
    string[] sr;

    List<Vector3> paths = new List<Vector3>();
    private void OnEnable()
    {
        rf = (ReadV3FromFile)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        filePath = EditorGUILayout.TextArea(filePath);

        if (GUILayout.Button("Update")) Configure();
    }

    private void Configure()
    {
        //C:/Users/davis.abols/Documents/Bear/V3.txt
        GetV3FromFile(filePath);

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    void GetV3FromFile(string file)
    {  
   
    if (File.Exists(file))
        {
            rf.points.Clear();
  
            sr = File.ReadAllLines(file);
         
            foreach (string s in sr)
            {
                string[] lineData = s.Split(',');
                float x = float.Parse(lineData[0], CultureInfo.InvariantCulture.NumberFormat);
                float y = float.Parse(lineData[1], CultureInfo.InvariantCulture.NumberFormat);
                float z = float.Parse(lineData[2], CultureInfo.InvariantCulture.NumberFormat);
                Debug.Log(new Vector3(x, y, z));
                paths.Add(new Vector3(x, y, z));
            }      
          
            rf.points = paths;
        }
        else
        {
            Debug.Log("Could not Open the file: " + file + " for reading.");
            return;
        }
    }

}
