using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music instance;
    public static Music Insetance=>instance;
    AudioSource musicSource;
    AudioSource soundSource;
    private void Awake() {
        instance=this;
        musicSource=GetComponents<AudioSource>()[0];
        soundSource=GetComponents<AudioSource>()[1];
    }
    void Start()
    {
        MusicData musicData=mGameData.Instance.musicData;
        SetMusicValue(musicData.musicValue);
        SetMusicOpen(musicData.musicOpen);
        SetSoundValue(musicData.soundValue);
        SetSoundOpen(musicData.soundOpen);
    }

    public void SetMusicOpen(bool open){
        musicSource.mute=!open;
    }
    public void SetMusicValue(float value){
        musicSource.volume=value;
    }
    public void SetSoundOpen(bool open){
        soundSource.mute=!open;
    }
    public void SetSoundValue(float value){
        soundSource.volume=value;
    }
}
