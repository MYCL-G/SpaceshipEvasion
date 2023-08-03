using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel : BasePanel<SetPanel>
{
    public Button btnClose;
    public Slider sliMusic;
    public Toggle togMusic;
    public Slider sliSound;
    public Toggle togSound;
    public override void Init()
    {
        btnClose.onClick.AddListener(()=>{
            Hide();
        });
        sliMusic.onValueChanged.AddListener((value)=>{
            mGameData.Instance.SetMusicValue(value);
            Music.Insetance.SetMusicValue(value);
        });
        togMusic.onValueChanged.AddListener((isOn)=>{
            mGameData.Instance.SetMusicOpen(isOn);
            Music.Insetance.SetMusicOpen(isOn);
        });
        sliSound.onValueChanged.AddListener((value)=>{
            mGameData.Instance.SetSoundValue(value);
            Music.Insetance.SetSoundValue(value);
        });
        togSound.onValueChanged.AddListener((isOn)=>{
            mGameData.Instance.SetSoundOpen(isOn);
            Music.Insetance.SetSoundOpen(isOn);
        });
        Hide();
    }
        public override void Hide()
    {
        base.Hide();
        mGameData.Instance.SaveMusicData();
    }
    public override void Show()
    {
        base.Show();
        MusicData musicData=mGameData.Instance.musicData;
        sliMusic.value=musicData.musicValue;
        togMusic.isOn=musicData.musicOpen;
        sliSound.value=musicData.soundValue;
        togSound.isOn=musicData.soundOpen;
    }
}
