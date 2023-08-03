using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankPanel : BasePanel<RankPanel>
{
    public Button btnClose;
    public GameObject content;
    public List<GameObject> pieces=new List<GameObject>();
    public TextMeshProUGUI[] texts;
    public override void Init()
    {
        btnClose.onClick.AddListener(() =>
        {
            Hide();
        });
        Hide();
    }
    public override void Show()
    {
        base.Show();
        List<RankInfo> rl = mGameData.Instance.rankData.rankList;
        if (rl.Count > 0)
        {
            while(pieces.Count<rl.Count){
                GameObject newPiece=Instantiate(Resources.Load<GameObject>("UI/RankItem"));
                pieces.Add(newPiece);
                newPiece.transform.SetParent(content.transform,false);
            }
            for (int i = 0; i < rl.Count; i++)
            {
                texts = pieces[i].GetComponentsInChildren<TextMeshProUGUI>();
                texts[0].text=(i+1).ToString();
                texts[1].text = rl[i].name;
                if (rl[i].time > 3600)
                    texts[2].text = rl[i].time / 3600 + "时" + rl[i].time / 60 % 60 + "分" + rl[i].time % 60 + "秒";
                else if (rl[i].time > 60)
                    texts[2].text = rl[i].time / 60 + "分" + rl[i].time % 60 + "秒";
                else
                    texts[2].text = rl[i].time + "秒";
            }
        }
    }
    public override void Hide()
    {
        base.Hide();

    }
}
