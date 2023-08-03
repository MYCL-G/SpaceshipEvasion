using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FirePosType
{
    TopLeft,
    Top,
    TopRight,
    Left,
    Right,
    BottomLeft,
    Bottom,
    BottomRight,
}
public class FireObj : MonoBehaviour
{
    public FirePosType firePosType;
    Vector3 screenPos;
    Vector3 initDir;
    FireInfo fireInfo;
    int nowNum;
    float nowCd;
    float nowDelay;
    float changeAngle;
    Vector3 nowDir;
    BulletInfo nowBullet;
    void Update()
    {
        UpdatePos();
        ResetFireInfo();
        UpdateFire();
    }
    void UpdatePos()
    {
        screenPos.z = 180;
        switch (firePosType)
        {
            case FirePosType.TopLeft:
                screenPos.x = 0;
                screenPos.y = Screen.height;
                initDir = Vector3.right;
                break;
            case FirePosType.Top:
                screenPos.x = Screen.width / 2;
                screenPos.y = Screen.height;
                initDir = Vector3.right;
                break;
            case FirePosType.TopRight:
                screenPos.x = Screen.width;
                screenPos.y = Screen.height;
                initDir = Vector3.left;
                break;
            case FirePosType.Left:
                screenPos.x = 0;
                screenPos.y = Screen.height / 2;
                initDir = Vector3.right;
                break;
            case FirePosType.Right:
                screenPos.x = Screen.width;
                screenPos.y = Screen.height / 2;
                initDir = Vector3.left;
                break;
            case FirePosType.BottomLeft:
                screenPos.x = 0;
                screenPos.y = 0;
                initDir = Vector3.right;
                break;
            case FirePosType.Bottom:
                screenPos.x = Screen.width / 2;
                screenPos.y = 0;
                initDir = Vector3.right;
                break;
            case FirePosType.BottomRight:
                screenPos.x = Screen.width;
                screenPos.y = 0;
                initDir = Vector3.left;
                break;
        }
        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }

    void ResetFireInfo()
    {
        if (nowCd != 0 && nowNum != 0) return;
        if (fireInfo != null)
        {
            nowDelay -= Time.deltaTime;
            if (nowDelay > 0) return;
        }
        List<FireInfo> fireInfoList = mGameData.Instance.fireData.fireInfoList;
        fireInfo = fireInfoList[Random.Range(0, fireInfoList.Count)];
        nowNum = fireInfo.num;
        nowCd = fireInfo.cd;
        nowDelay = fireInfo.delay;
        string[] strs = fireInfo.ids.Split(",");
        int beginId = int.Parse(strs[0]);
        int endId = int.Parse(strs[1]);
        int randomBulletId = Random.Range(beginId, endId + 1);
        nowBullet = mGameData.Instance.bulletData.bulletInfoList[randomBulletId - 1];
        if (fireInfo.type == 2)
        {
            switch (firePosType)
            {
                case FirePosType.Top:
                case FirePosType.Bottom:
                case FirePosType.Left:
                case FirePosType.Right:
                    changeAngle = 90f / nowNum;
                    break;
                case FirePosType.TopLeft:
                case FirePosType.TopRight:
                case FirePosType.BottomLeft:
                case FirePosType.BottomRight:
                    changeAngle = 180f / nowNum;
                    break;
            }
        }
    }

    void UpdateFire()
    {
        if(nowCd==0&&nowNum==0) return;
        nowCd -= Time.deltaTime;
        if (nowCd > 0) return;
        GameObject bullet;
        BulletObj bulletObj;
        switch (fireInfo.type)
        {
            case 1:
                bullet = Instantiate(Resources.Load<GameObject>(nowBullet.resName));
                bulletObj = bullet.AddComponent<BulletObj>();
                bulletObj.InitInfo(nowBullet);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.LookRotation(PlayerObj.Instance.transform.position - transform.position);
                nowNum--;
                nowCd = nowNum == 0 ? 0 : fireInfo.cd;
                break;
            case 2:
                if (fireInfo.cd == 0)
                {
                    for (int i = 0; i < nowNum; i++)
                    {
                        bullet = Instantiate(Resources.Load<GameObject>(nowBullet.resName));
                        bulletObj = bullet.AddComponent<BulletObj>();
                        bulletObj.InitInfo(nowBullet);
                        bullet.transform.position = transform.position;
                        nowDir = Quaternion.AngleAxis(changeAngle * i, Vector3.up) * initDir;
                        bullet.transform.rotation = Quaternion.LookRotation(nowDir);
                        nowNum = 0;
                        nowCd = 0;
                    }
                }
                else
                {
                    bullet = Instantiate(Resources.Load<GameObject>(nowBullet.resName));
                    bulletObj = bullet.AddComponent<BulletObj>();
                    bulletObj.InitInfo(nowBullet);
                    bullet.transform.position = transform.position;
                    nowDir = Quaternion.AngleAxis(changeAngle * (fireInfo.num - nowNum), Vector3.up) * initDir;
                    bullet.transform.rotation = Quaternion.LookRotation(nowDir);
                    nowNum--;
                    nowCd = nowNum == 0 ? 0 : fireInfo.cd;
                }
                break;
        }
    }
}
