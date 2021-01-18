using System;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecordEvent : EditorWindow
{
    int timeCodeSeconds;
    int timeCodeMinutes;
    int inputOffsetSeconds;
    int inputOffsetMinutes;
    string movementID;
    LevelID levelID;
    bool record;

    [MenuItem("Window/RecordEvent")]
    public static void ShowWindow()
    {
        GetWindow<RecordEvent>("RecordEvent");
    }

    private void OnGUI()
    {
        Record();
    }

    void Record() {
        movementID = EditorGUILayout.TextField("Movement ID", movementID);
        levelID = (LevelID)EditorGUILayout.EnumPopup("LevelID", levelID);
        GUILayout.Label("TimeCode", EditorStyles.boldLabel);
        timeCodeMinutes = EditorGUILayout.IntField("Minutes", timeCodeMinutes);
        timeCodeSeconds = EditorGUILayout.IntField("Seconds", timeCodeSeconds);
        GUILayout.Label("InputOffset", EditorStyles.boldLabel);
        inputOffsetMinutes = EditorGUILayout.IntField("Minutes", inputOffsetMinutes);
        inputOffsetSeconds = EditorGUILayout.IntField("Seconds", inputOffsetSeconds);
        record = EditorGUILayout.Toggle("Record", record);
        if (record) {
            SaveEvents.SaveEvent(timeCodeMinutes, timeCodeSeconds, inputOffsetMinutes, inputOffsetSeconds, movementID, levelID);
            record = false;
        }
    }
}