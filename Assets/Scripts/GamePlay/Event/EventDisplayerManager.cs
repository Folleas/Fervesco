using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDisplayerManager : MonoBehaviour {
    public EventManager eventManager;
    public GameObject eventDisplayer;
    public Event currentEvent;
    public Texture rightUp;
    public Texture rightDown;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Event lastEvent = eventManager.currentEvent;
        if (lastEvent != currentEvent) {
            currentEvent = lastEvent;
            switch (currentEvent.getMovementID()) {
                case "RightUp":
                    eventDisplayer.GetComponent<Renderer>().sharedMaterial.SetTexture("_Texture", rightUp);
                    break;
                case "LeftRight":
                    eventDisplayer.GetComponent<Renderer>().sharedMaterial.SetTexture("_Texture", rightDown);
                    break;
            }
        }
    }
}
