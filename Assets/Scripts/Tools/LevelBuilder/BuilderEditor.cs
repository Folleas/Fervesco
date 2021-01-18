//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using UnityEngine.SceneManagement;

//[CustomEditor(typeof(Builder))]
//public class BuilderEditor : Editor {
//    Builder mTarget;

//    public void OnSceneGUI() {
//        mTarget = (Builder)target;

//        Handles.color = Color.green;
//        if (Handles.Button(mTarget.transform.position + Vector3.down, Quaternion.identity, 1f, 1f, Handles.CubeHandleCap))
//            mTarget.PlaceObject();
//        RaycastHit hit;
//        Vector3 mousePosition = Input.mousePosition;
//        Debug.Log(mousePosition);
//        Ray ray = HandleUtility.GUIPointToWorldRay(new Vector2(mousePosition.x, mousePosition.y));
//        if (Physics.Raycast(ray, out hit, 100.0f)) {
//            Debug.Log("You selected the " + hit.transform.name);
//        }
//    }

//}
