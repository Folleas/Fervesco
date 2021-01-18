using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public LevelID levelID;
    AudioSource audioSource;
    public AudioClip audioClip;
    public bool paused = false;
    bool musicPlayed = false;

    private void Awake() {
        audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        audioSource.clip = Resources.Load("Music/Music1") as AudioClip;
    }
    private void Update() {
        Debug.Log("MusisManager : " + paused);
        if (!paused) {
            if (!musicPlayed) {
                audioSource.Play();
                musicPlayed = true;
            }
            else
                audioSource.UnPause();
        }
        else {
            audioSource.Pause();
        }
    }
}
