using UnityEngine;
using UnityEditor;

public class CameraWaypoints : EditorWindow
{
    Vector2 scrollPos;

    [MenuItem("Window/CameraWaypoints")]
    public static void ShowWindow()
    {
        GetWindow<CameraWaypoints>("CameraWaypoints");
    }


    void OnGUI() {
        if (GUILayout.Button("New Waypoint")) {
            CreateNewWaypoint();
        }
        DisplayWaypointsInfo();
    }

    void DisplayWaypointsInfo() {
        GameObject waypoints = GameObject.FindGameObjectWithTag("WaypointsManager");
        GUILayout.BeginVertical();
        scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);
        for (int i = 0; i < waypoints.transform.childCount; i++) {
            GUILayout.Label("Waypoint " + i, EditorStyles.boldLabel);
            Transform child = waypoints.transform.GetChild(i);
            GUILayout.Label("Position   x: " + child.transform.position.x + " y: " + child.transform.position.y + " z: " + child.transform.position.z, EditorStyles.label);
            GUILayout.Label("Rotation   x: " + child.transform.rotation.x + " y: " + child.transform.rotation.y + " z: " + child.transform.rotation.z, EditorStyles.label);
            GUILayout.Label("FOV        " + child.GetComponent<WaypointData>().FOV, EditorStyles.label);
        }
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
    }

    void CreateNewWaypoint() {
        GameObject waypoint = Instantiate((GameObject)Resources.Load("Prefabs/Waypoint", typeof(GameObject)));
        GameObject waypoints = GameObject.FindGameObjectWithTag("WaypointsManager");
        waypoint.transform.SetParent(waypoints.transform);
    }
}
