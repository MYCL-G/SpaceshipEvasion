using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BulletData
{
    public List<BulletInfo> bulletInfoList=new List<BulletInfo>();
}
public class BulletInfo{
    [XmlAttribute]
    public int id;
    [XmlAttribute]
    public int type;
    [XmlAttribute]
    public float forwardSpeed;//正向
    [XmlAttribute]
    public float ringhtSpeed;//横向
    [XmlAttribute]
    public float roundSpeed;//旋转
    [XmlAttribute]
    public string resName;
    [XmlAttribute]
    public string deadEff;//死亡特效
    [XmlAttribute]
    public float lifeTime;
}
