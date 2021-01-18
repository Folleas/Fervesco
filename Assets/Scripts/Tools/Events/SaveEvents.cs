using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;

public static class SaveEvents {

    public static void SaveEvent(int timeCodeMinutes, int timeCodeSeconds, int inputOffsetMinutes, int inputOffsetSeconds, string movementID, LevelID levelID)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Events/" + levelID + ".event";

        if (File.Exists(path)) {
            List<EventData> events = LoadEvents(levelID);
            EventData data = new EventData(timeCodeMinutes, timeCodeSeconds, inputOffsetMinutes, inputOffsetSeconds, movementID);
            FileStream stream = new FileStream(path, FileMode.Open);

            events.Add(data);
            formatter.Serialize(stream, events);
            stream.Close();
        }
        else {
            EventData move = new EventData(timeCodeMinutes, timeCodeSeconds, inputOffsetMinutes, inputOffsetSeconds, movementID);
            List<EventData> events = new List<EventData>();
            FileStream stream = new FileStream(path, FileMode.Create);

            events.Add(move);
            formatter.Serialize(stream, events);
            stream.Close();
        }
    }

    public static List<EventData> LoadEvents(LevelID levelID)
    {
        string path = Application.persistentDataPath + "/Events/" + levelID + ".event";
        if (File.Exists(path)) { 
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<EventData> events = formatter.Deserialize(stream) as List<EventData>;
            stream.Close();

            return events;
        }
        else {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}