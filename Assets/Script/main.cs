using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    void Start()
    {
        RoleInfo roleInfo=mGameData.Instance.GetNowHeroInfo();
        GameObject obj=Instantiate(Resources.Load<GameObject>(roleInfo.resName));
        PlayerObj playerObj=obj.AddComponent<PlayerObj>();
        playerObj.speed=roleInfo.speed*20;
        playerObj.maxHp=10;
        playerObj.roundSpeed=20;
        playerObj.nowHp=roleInfo.hp;
        GamePanel.Instance.ChangeHp(playerObj.nowHp);
    } 
    void Update()
    {
        
    }
}
