using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class RankData
{
    public List<RankInfo> rankList=new List<RankInfo>();
}
public class RankInfo{
    [XmlAttribute]
    public string name;
    [XmlAttribute]
    public int time;
    public RankInfo(){}
    public RankInfo(string name,int time){
        this.name=name;
        this.time=time;
    }
}
