using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;

public static class SaveMovements {
    
    public static void SaveMovement(string movementID, int[] grid)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Movements/" + movementID + ".mv";

        if (File.Exists(path)) {
            List<MovementData> moves = LoadMovement(movementID);
            MovementData data = new MovementData(grid);
            FileStream stream = new FileStream(path, FileMode.Open);

            moves.Add(data);
            formatter.Serialize(stream, moves);
            stream.Close();
        }
        else {
            MovementData move = new MovementData(grid);
            List<MovementData> moves = new List<MovementData>();
            FileStream stream = new FileStream(path, FileMode.Create);

            moves.Add(move);
            formatter.Serialize(stream, moves);
            stream.Close();
        }
    }

    public static List<MovementData> LoadMovement(string movementID)
    {
        string path = Application.persistentDataPath + "/Movements/" + movementID + ".mv";
        if (File.Exists(path)) { 
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<MovementData> moves = formatter.Deserialize(stream) as List<MovementData>;
            stream.Close();

            return moves;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}