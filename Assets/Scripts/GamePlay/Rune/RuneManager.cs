using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoBehaviour
{
    public GameObject snapPointContainer;
    SnapPoint[] snapPoints;
    List<int> connectedSnapPoints;
    public bool playerDrawing = false;

    void Start()
    {
        connectedSnapPoints = new List<int>();
        snapPoints = snapPointContainer.GetComponentsInChildren<SnapPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDrawing) {
            foreach (SnapPoint snapPoint in snapPoints) {
                if (snapPoint.isSelected() && canConnectSnapPoint(snapPoint.id)) {
                    connectedSnapPoints.Add(snapPoint.id);
                }
            }
        }
        else {
            for (int i = 0; i != connectedSnapPoints.Count; i++) {
                Debug.Log(i + ": " + connectedSnapPoints[i]);
            }
            connectedSnapPoints.Clear();
        }
    }

    bool canConnectSnapPoint(int id) {
        //connectedSnapPoints.Contains(snapPoint.id)
        if (connectedSnapPoints.Count == 1 && connectedSnapPoints.Contains(id)) {
            return false;
        }
        else if (connectedSnapPoints.Count >= 1 && connectedSnapPoints[connectedSnapPoints.Count - 1] == id) {
            return false;
        }
        if (connectedSnapPoints.Count >= 2 && connectedSnapPoints[connectedSnapPoints.Count - 2] == id) {
            return false;
        }
        return true;
    }
}
