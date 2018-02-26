using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(ReadV3FromFile))]
public class ReadV3FromFileEditor : Editor
{

    private ReadV3FromFile rf;


    Vector3[] positionArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f) };

    private void OnEnable()
    {
        rf = (ReadV3FromFile)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Update")) Configure();
    }

    private void Configure()
    {

        rf.V3Array = positionArray;

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }


}
