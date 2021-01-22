using System;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class RecordMovement : EditorWindow
{
    bool recording = false;
    string movementID = "";
    string label = "Toggle record to save GridManager input";
    private GridManager gridManager = null;

    [MenuItem("Window/RecordMovement")]
    public static void ShowWindow()
    {
        GetWindow<RecordMovement>("RecordMovement");
    }

    private void OnGUI()
    {
        Record();
        ShowRecordedMoves();
    }

    void ShowRecordedMoves() {
        GUILayout.Label("\nRecorded Movements", EditorStyles.boldLabel);
        GUILayout.Label("MoveID", EditorStyles.miniLabel);
        var info = new System.IO.DirectoryInfo(Application.persistentDataPath + "/Movements/");
        var fileInfo = info.GetFiles();
        
        foreach (var file in fileInfo) {
            EditorGUILayout.LabelField(file.Name.Replace(".mv", ""));
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
            int[] gridState = gridManager.getGridState().grid;
            if (gridState != null)
            {
                SaveMovements.SaveMovement(movementID, gridState, gridManager.width, gridManager.height);
                recording = false;
            }
        }
        else
        {
            label = "Please toggle recording off, enter ID and reference to gridManager first";
        }
    }
}