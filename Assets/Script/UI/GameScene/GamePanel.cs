using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePanel : BasePanel<GamePanel>
{
    public Button btnBack;
    public TextMeshProUGUI textTime;
    public List<GameObject> hpList=new List<GameObject>();
    public float nowTime=0;
    public override void Init()
    {
        btnBack.onClick.AddListener(()=>{
            QuitPanel.Instance.Show();
            Time.timeScale=0;
        });
    }
    private void Update() {
        nowTime+=Time.deltaTime;
        if(nowTime<60) textTime.text=(int)nowTime+"秒";
        else if(nowTime<3600) textTime.text=(int)nowTime/60+"分"+(int)nowTime%60+"秒";
        else textTime.text=(int)nowTime/3600+"时"+(int)nowTime%60/60+"分"+(int)nowTime%60+"秒";
    }
    public void ChangeHp(int hp){
        for(int i=0;i<10;i++){
            hpList[i].SetActive(i<hp);
        }
    }
        
}
