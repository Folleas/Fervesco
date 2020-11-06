using System;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class RecordMove : EditorWindow
{
    bool recording = false;
    string movementID = "";
    string label = "Toggle record to save GridManager input";
    private GridManager gridManager = null;

    [MenuItem("Window/RecordMove")]
    public static void ShowWindow()
    {
        GetWindow<RecordMove>("RecordMove");
    }

    private void OnGUI()
    {
        Record();
        ShowRecordedMoves();
    }

    void ShowRecordedMoves() {
        GUILayout.Label("\nRecorded Moves", EditorStyles.boldLabel);
        GUILayout.Label("MoveID                                     nb", EditorStyles.miniLabel);
        var info = new System.IO.DirectoryInfo(Application.persistentDataPath + "/");
        var fileInfo = info.GetFiles();
        
        foreach (var file in fileInfo) {
            EditorGUILayout.LabelField(file.Name.Replace(".mv", ""), SaveMouvement.LoadMouvement(file.Name.Replace(".mv", "")).Count.ToString());
        }
    }

    void Record() { 
        GUILayout.Label(label, EditorStyles.boldLabel);

        recording = EditorGUILayout.Toggle("Record", recording);
        movementID = EditorGUILayout.TextField("MoveID", movementID);
        gridManager = EditorGUILayout.ObjectField(gridManager, typeof(GridManager), true) as GridManager;

        if (recording) {
            Recording();
        }
        else {
            label = "Toggle record to save GridManager input";
        }
    }

    void Recording()
    {
        if (movementID != "" && gridManager != null)
        {
            label = "Recording";
            int[] gridState = gridManager.getGridState();
            if (gridState != null)
            {
                SaveMouvement.SaveMouv(movementID, gridState);
                recording = false;
            }
        }
        else
        {
            label = "Please toggle recording off, enter ID and reference to gridManager first";
        }
    }
}