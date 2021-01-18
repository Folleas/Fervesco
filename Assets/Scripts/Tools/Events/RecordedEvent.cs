using System;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecordedEvent : EditorWindow
{
    LevelID levelID = LevelID.UNDEFINED;
    Vector2 scrollPos;

    [MenuItem("Window/RecordedEvent")]
    public static void ShowWindow()
    {
        GetWindow<RecordedEvent>("RecordedEvent");
    }

    private void OnGUI()
    {
        levelID = (LevelID)EditorGUILayout.EnumPopup("Level ID", levelID);
        if (levelID != LevelID.UNDEFINED)
            ShowRecordedEvents();
    }
    void ShowRecordedEvents() {
        GUILayout.Label("Recorded Events", EditorStyles.boldLabel);
        List<EventData> eventsData = SaveEvents.LoadEvents(levelID);

        GUILayout.BeginVertical();
        scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);
        if (eventsData != null) {
            foreach (EventData data in eventsData) {
                GUILayout.Label("Movement ID\t: " + data.movementID, EditorStyles.label);
                GUILayout.Label("TimeCode\t: " + data.timeCodeMinutes.ToString() + ":" + data.timeCodeSeconds.ToString(), EditorStyles.label);
                GUILayout.Label("InputOffset\t: " + data.inputOffsetMinutes.ToString() + ":" + data.inputOffsetSeconds.ToString() + "\n", EditorStyles.label);
            }
        }
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
    }
}