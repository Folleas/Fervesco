using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TimeCode {
    public int minute;
    public int second;
}

public enum EventStatus {
    SUCCESS, FAILURE, UNDEFINED
}
public class Event
{
    TimeCode timecode;
    TimeCode inputOffset;
    string movementID;
    EventStatus status;

    public Event(TimeCode timecode, TimeCode inputOffset, string movementID) {
        this.timecode = timecode;
        this.inputOffset = inputOffset;
        this.movementID = movementID;
        this.status = EventStatus.UNDEFINED;
    }
    
    public float getTimeCodeInSeconds() {
        return this.timecode.minute * 60 + this.timecode.second;
    }
    public float getInputOffsetInSeconds() {
        return this.inputOffset.minute * 60 + this.inputOffset.second;
    }
    public TimeCode getTimeCode() {
        return this.timecode;
    }
    public TimeCode getInputOffset() {
        return this.inputOffset;
    }
    public string getMovementID() {
        return this.movementID;
    }
    public EventStatus getStatus() {
        return this.status;
    }
    public void setStatus(EventStatus status) {
        this.status = status;
    }

}
