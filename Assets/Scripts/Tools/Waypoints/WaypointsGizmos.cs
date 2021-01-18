using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WaypointsGizmos : MonoBehaviour
{
    public float size = 1;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, size);
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction);
    }
}
