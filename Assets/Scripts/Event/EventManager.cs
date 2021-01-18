using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GridManager gridManager;
    List<Event> events;
    public bool paused = false;
    string eventsPath;
    float chrono = 0;
    int eventIndex = 0;
    public LevelID levelID = LevelID.UNDEFINED;

    void Start()
    {
        List<EventData> eventsData = SaveEvents.LoadEvents(levelID);
        this.events = EventDataToEvent(eventsData);
    }
    void Update()
    {
        if (!paused) {
            chrono += Time.deltaTime;
            if (events.Count > eventIndex) {
                float timeCodeSeconds = events[eventIndex].getTimeCodeInSeconds();
                if (chrono >= timeCodeSeconds) {
                    MovementData data = gridManager.getGridState();
                    Debug.Log("INPUT : " + eventIndex + " " + chrono);
                    if (data.grid != null) {
                        //check grid
                    }
                    float inputOffsetSeconds = events[eventIndex].getInputOffsetInSeconds();
                    if (chrono >= timeCodeSeconds + inputOffsetSeconds) {
                        Debug.Log("TOO LATE : " + eventIndex + " " + chrono);
                        eventIndex++;
                    }
                }
            }
        }
        else {
        }
    }

    List<Event> EventDataToEvent(List<EventData> eventsData) {
        List<Event> events = new List<Event>();;

        foreach (EventData data in eventsData) {
            TimeCode timeCode;
            timeCode.minute = data.timeCodeMinutes;
            timeCode.second = data.timeCodeSeconds;

            TimeCode inputOffset;
            inputOffset.minute = data.inputOffsetMinutes;
            inputOffset.second = data.inputOffsetSeconds;

            Event eventTemp = new Event(timeCode, inputOffset, data.movementID);

            events.Add(eventTemp);
        }
        return events;
    }
}
