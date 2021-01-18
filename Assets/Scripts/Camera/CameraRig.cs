using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public float speed = 5f;

    private List<GameObject> waypoints = new List<GameObject>();
    private int waypointsIndex = 0;

    private void Awake() {
        GameObject waypointManager = GameObject.FindGameObjectWithTag("WaypointsManager");
        for (int i = 0; i != waypointManager.transform.childCount; i++) {
            waypoints.Add(waypointManager.transform.GetChild(i).gameObject);
        }
        if (waypoints.Count > 0) {
            transform.rotation = waypoints[waypointsIndex].transform.rotation;
            transform.position = waypoints[waypointsIndex++].transform.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
    {
        Vector3 AB = b - a;
        Vector3 AV = value - a;
        return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
    }
    void ManageAngle() {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, waypoints[waypointsIndex].transform.rotation, InverseLerp(waypoints[waypointsIndex - 1].transform.position, waypoints[waypointsIndex].transform.position, transform.position));
    }

    void ManagePosition() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, step);
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointsIndex < waypoints.Count) {
            ManagePosition();
            ManageAngle();
            if (transform.position == waypoints[waypointsIndex].transform.position) {
                waypointsIndex++;
            }
        }
    }
}
