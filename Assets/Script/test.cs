using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    void Start()
    {
        mGameData.Instance.rankData.rankList=new List<RankInfo>();
        mXmlData.Instance.SaveData(mGameData.Instance.rankData,"RankData");
        mGameData.Instance.AddRankData("测试人员1",10);
        mGameData.Instance.AddRankData("测试人员2",20);
        mGameData.Instance.AddRankData("测试人员3",30);
        mGameData.Instance.AddRankData("测试人员4",40);
    }
}
