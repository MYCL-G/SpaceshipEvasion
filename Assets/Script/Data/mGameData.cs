using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mGameData
{
    static mGameData instance = new mGameData();
    public static mGameData Instance => instance;
    public MusicData musicData;
    public RankData rankData;
    public RoleData roleData;
    public BulletData bulletData;
    public FireData fireData;
    public int nowHeroIndex=0;
    private mGameData()
    {
        musicData = mXmlData.Instance.LoadData(typeof(MusicData), "MusicData") as MusicData;
        rankData = mXmlData.Instance.LoadData(typeof(RankData), "RankData") as RankData;
        roleData = mXmlData.Instance.LoadData(typeof(RoleData), "RoleData") as RoleData;
        bulletData = mXmlData.Instance.LoadData(typeof(BulletData), "BulletData") as BulletData;
        fireData = mXmlData.Instance.LoadData(typeof(FireData), "FireData") as FireData;
    }

    #region 音乐音效
    public void SaveMusicData()
    {
        mXmlData.Instance.SaveData(musicData, "MusicData");
    }
    public void SetMusicOpen(bool open)
    {
        musicData.musicOpen = open;
    }
    public void SetMusicValue(float value)
    {
        musicData.musicValue = value;
    }
    public void SetSoundOpen(bool open)
    {
        musicData.soundOpen = open;
    }
    public void SetSoundValue(float value)
    {
        musicData.soundValue = value;
    }
    #endregion
    public void AddRankData(string name, int time)
    {
        rankData.rankList.Add(new RankInfo(name, time));
        rankData.rankList.Sort((a, b) =>
        {
            if (a.time > b.time) return -1;
            else return 1;
        });
        if (rankData.rankList.Count > 20) rankData.rankList.RemoveAt(20);
        mXmlData.Instance.SaveData(rankData,"RankData");
    }
    public RoleInfo GetNowHeroInfo(){
        return  roleData.roleList[nowHeroIndex];
    }
}
