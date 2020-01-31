using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public SoundLibrary soundLibrary;
    public List<AudioSource> activeSoundSourcePool =  new List<AudioSource>();
    public List<AudioSource> inactiveSoundSourcePool = new List<AudioSource>();
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        inactiveSoundSourcePool.Add(new GameObject().AddComponent(typeof(AudioSource)) as AudioSource);
    }

    public void PlaySound( SoundData soundModel)
    {
        if (inactiveSoundSourcePool.Count > 0) 
        {
            inactiveSoundSourcePool[0].clip = soundModel.audioClip;
            inactiveSoundSourcePool[0].Play();
            activeSoundSourcePool.Add(inactiveSoundSourcePool[0]);
            inactiveSoundSourcePool.Remove(inactiveSoundSourcePool[0]);
            return;
        }
        AudioSource newSoundSource = new GameObject().AddComponent(typeof(AudioSource)) as AudioSource;
        newSoundSource.clip = soundModel.audioClip;
        newSoundSource.Play();
        inactiveSoundSourcePool.Add(newSoundSource);
    }

    void Update() 
    {
        for (int i = 0; i < activeSoundSourcePool.Count; i++)
        {
            if (!activeSoundSourcePool[i].isPlaying) 
            {
                inactiveSoundSourcePool.Add(activeSoundSourcePool[0]);
                activeSoundSourcePool.Remove(activeSoundSourcePool[0]);
            }
        }
    }
        
}
