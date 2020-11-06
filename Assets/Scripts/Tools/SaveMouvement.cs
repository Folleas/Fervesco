using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;

public static class SaveMouvement {
    
    public static void SaveMouv(string movementID, int[] grid)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + movementID + ".mv";

        if (File.Exists(path)) {
            List<MouvementData> moves = LoadMouvement(movementID);
            MouvementData data = new MouvementData(grid);
            FileStream stream = new FileStream(path, FileMode.Open);

            moves.Add(data);
            formatter.Serialize(stream, moves);
            stream.Close();
        }
        else {
            MouvementData move = new MouvementData(grid);
            List<MouvementData> moves = new List<MouvementData>();
            FileStream stream = new FileStream(path, FileMode.Create);

            moves.Add(move);
            formatter.Serialize(stream, moves);
            stream.Close();
        }
    }

    public static List<MouvementData> LoadMouvement(string movementID)
    {
        string path = Application.persistentDataPath + "/" + movementID + ".mv";
        if (File.Exists(path)) { 
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<MouvementData> moves = formatter.Deserialize(stream) as List<MouvementData>;
            stream.Close();

            return moves;
        }
        else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
