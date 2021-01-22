using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;

public static class SaveMovements {
    
    public static void SaveMovement(string movementID, int[] grid, int width, int height)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Movements/" + movementID + ".mv";

        if (File.Exists(path)) {
            MovementData movement = new MovementData(movementID, grid, width, height);
            FileStream stream = new FileStream(path, FileMode.Open);

            formatter.Serialize(stream, movement);
            stream.Close();
        }
        else {
            MovementData movement = new MovementData(movementID, grid, width, height);
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, movement);
            stream.Close();
        }
    }

    public static MovementData LoadMovement(string movementID)
    {
        string path = Application.persistentDataPath + "/Movements/" + movementID + ".mv";
        if (File.Exists(path)) { 
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            MovementData move = formatter.Deserialize(stream) as MovementData;

            stream.Close();
            return move;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}