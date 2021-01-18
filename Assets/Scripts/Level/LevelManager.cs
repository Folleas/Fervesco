using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelID {
    UNDEFINED, Level1, Level2, Level3, Level4, Level5
}

public class LevelManager : MonoBehaviour
{
    public bool paused = false;
    public LevelID levelID = LevelID.UNDEFINED;
    void Awake()
    {
        GetComponentInChildren<EventManager>().levelID = levelID;
        GetComponentInChildren<EventManager>().paused = paused;
        GetComponentInChildren<MusicManager>().levelID = levelID;
        GetComponentInChildren<MusicManager>().paused = paused;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (paused)
                paused = false;
            else
                paused = true;
            GetComponentInChildren<EventManager>().paused = paused;
            GetComponentInChildren<MusicManager>().paused = paused;
        }
    }
}
