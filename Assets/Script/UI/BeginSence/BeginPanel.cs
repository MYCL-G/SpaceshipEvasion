using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel<BeginPanel>
{
    public Button btnStart;
    public Button btnRank;
    public Button btnSet;
    public Button btnQuit;
    public override void Init()
    {
        btnStart.onClick.AddListener(()=>{
            Hide();
            ChoosePanel.Instance.Show();
        });
        btnRank.onClick.AddListener(()=>{
            //排行榜面板
            RankPanel.Instance.Show();
        });
        btnSet.onClick.AddListener(()=>{
            //设置面板
            SetPanel.Instance.Show();
        });
        btnQuit.onClick.AddListener(()=>{
            Application.Quit();
        });
    }

}
