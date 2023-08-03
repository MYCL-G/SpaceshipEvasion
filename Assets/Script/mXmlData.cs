using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System;

public class mXmlData
{
    static mXmlData instance=new mXmlData();
    public static mXmlData Instance=>instance;
    
    public void SaveData(object data, string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".xml";
        using (StreamWriter SW = new StreamWriter(path))
        {
            XmlSerializer XS = new XmlSerializer(data.GetType());
            XS.Serialize(SW, data);
        }
    }
    public object LoadData(Type type, string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".xml";
        if (!File.Exists(path)) path = Application.streamingAssetsPath + "/" + fileName + ".xml";
        if (File.Exists(path))
        {
            using (StreamReader SR = new StreamReader(path))
            {
                XmlSerializer XS = new XmlSerializer(type);
                return XS.Deserialize(SR);
            }
        }
        return Activator.CreateInstance(type);
    }
}