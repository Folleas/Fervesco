using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject source;
    public void PlaceObject() {
        Debug.Log("PlaceObject");
        if (source) {
            GameObject obj = Instantiate(source) as GameObject;
        }
    }
}
