using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void SetVolume(float volume) {
        Debug.Log("Volume: " + volume);
    }

    public void SetSoundEffect(float volume) {
        Debug.Log("SoundEffect: " + volume);
    }
}
