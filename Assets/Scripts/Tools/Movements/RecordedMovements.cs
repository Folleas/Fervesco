using System;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class RecordedMovements : EditorWindow
{
    [MenuItem("Window/RecordedMovements")]
    public static void ShowWindow()
    {
        GetWindow<RecordedMovements>("RecordedMovements");
    }

    private void OnGUI()
    {
        ShowRecordedMoves();
    }

    void ShowRecordedMoves() {
        GUILayout.Label("\nRecorded Movements", EditorStyles.boldLabel);
        GUILayout.Label("MoveID                                     nb", EditorStyles.miniLabel);
        var info = new System.IO.DirectoryInfo(Application.persistentDataPath + "/Movements/");
        var fileInfo = info.GetFiles();
        
        foreach (var file in fileInfo) {
            EditorGUILayout.LabelField(file.Name.Replace(".mv", ""), SaveMovements.LoadMovement(file.Name.Replace(".mv", "")).Count.ToString());
        }
    }
}