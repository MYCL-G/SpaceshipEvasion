using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndPanel : BasePanel<EndPanel>
{
    public Button btnSure;
    public TextMeshProUGUI textTime;
    public TMP_InputField inpName;
    int endTime;
    public override void Init()
    {
        btnSure.onClick.AddListener(()=>{
            mGameData.Instance.AddRankData(inpName.text,endTime);
            Time.timeScale=1;
            SceneManager.LoadScene("BeginScene");
        });
        Hide();
    }
    public override void Show()
    {
        base.Show();
        endTime=(int)GamePanel.Instance.nowTime;
        textTime.text=GamePanel.Instance.textTime.text;
    }
}
