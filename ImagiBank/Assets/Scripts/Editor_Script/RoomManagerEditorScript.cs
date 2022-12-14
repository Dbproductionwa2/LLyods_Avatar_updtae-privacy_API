#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditorScript : Editor
{

   
    // Start is called before the first frame update
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for connecting to photon servers.", MessageType.Info);

        RoomManager roomManager = (RoomManager)target;
        if (GUILayout.Button("Connect Anonymously"))
        {
            roomManager.JoinRandomRoom();
        }
    }
}
#endif