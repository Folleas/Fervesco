using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventData {
    public int timeCodeMinutes;
    public int timeCodeSeconds;
    public int inputOffsetMinutes;
    public int inputOffsetSeconds;
    public string movementID;

    public EventData(int timeCodeMinutes, int timeCodeSeconds, int inputOffsetMinutes, int inputOffsetSeconds, string movementID) {
        this.timeCodeMinutes = timeCodeMinutes;
        this.timeCodeSeconds = timeCodeSeconds;
        this.inputOffsetSeconds = inputOffsetSeconds;
        this.inputOffsetMinutes = inputOffsetMinutes;
        this.movementID = movementID;
    }
}
