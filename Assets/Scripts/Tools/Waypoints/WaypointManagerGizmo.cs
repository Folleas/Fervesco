using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManagerGizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount - 1; i++) {
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);
        }
    }
}
