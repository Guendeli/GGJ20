using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "soundLibrary", menuName = "Custom/SoundSystem")]

public class SoundLibrary : ScriptableObject
{
    public SoundData[] allSounds;

    public SoundData GetSoundByID(string soundId) 
    {
        foreach (SoundData item in allSounds)
        {
            if (item.soundID == soundId) return item;
        }
        Debug.LogError(string.Format("Sound model with id {0} not found", soundId));
        return null;
    }
}
