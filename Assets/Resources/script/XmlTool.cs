using UnityEngine;
using System.Collections;
using System.Xml;

using System;

public class XmlTool{

    //private XmlDocument m_XmlFile = null;
    // Singotan
    private static XmlTool _instance;
    public static XmlTool Instance
    {
        get
        {
            if (_instance == null)
                _instance = new XmlTool();
            return _instance;
        }
    }

    public XmlTool() {
        //m_XmlFile = new XmlDocument();
    }

    public string LoadXmlFile(string FileName,string UnitName,string TagName,int UnitID = -1)//傳入的是 "Gacha", "Job","Name"
    {
        //讀取檔案
        XmlDocument m_XmlFile = null;
        m_XmlFile = new XmlDocument();
        string FilePos = "Data/" + FileName;
        TextAsset t = Resources.Load(FilePos) as TextAsset;
        m_XmlFile.LoadXml(t.text);
        //讀取Root,並將所有子節點存入node
        XmlNodeList nodes = m_XmlFile.SelectSingleNode("Root").ChildNodes;

        foreach (XmlElement node in nodes)//NodeUnit階層
        {
            //先找到目標Unit
            string NodeID = node.GetAttribute("ID");
            string InID = UnitID.ToString();
            if (false == NodeID.Equals(InID))//如果不是正確ID跳過
                continue;
            //尋找Tag內容
            foreach (XmlElement Element in node)
            {
                if (Element.Name == TagName)
                {
                    return Element.InnerText;
                }
            }



        }
        return "";
    }

    public T LoadXmlFileAttr<T>(string FileName, string UnitName, string TagName, int UnitID = -1)//傳入的是 "Gacha", "Job","Name"
    {
        //讀取檔案
        XmlDocument m_XmlFile = null;
        m_XmlFile = new XmlDocument();
        string FilePos = "Data/" + FileName;
        TextAsset t = Resources.Load(FilePos) as TextAsset;
        m_XmlFile.LoadXml(t.text);
        //讀取Root,並將所有子節點存入node
        XmlNodeList nodes = m_XmlFile.SelectSingleNode("Root").ChildNodes;

        foreach (XmlElement node in nodes)//NodeUnit階層
        {
            //先找到目標Unit
            string NodeID = node.GetAttribute("ID");
            string InID = UnitID.ToString();
            if (false == NodeID.Equals(InID))//如果不是正確ID跳過
                continue;
            //尋找Tag內容
            foreach (XmlElement Element in node)
            {
                if (Element.Name == TagName)
                {
                    string Value = Element.InnerText;
                    return (T)Convert.ChangeType(Value, typeof(T));
                }
            }
        }
        return (T)Convert.ChangeType(-1, typeof(T));
    }

    /*public Hashtable LoadObjectList(string XsdName, string XmlName)//傳入的是 "Gacha", "Job","Name"
    {
        //讀取檔案
        Hashtable tempHashTable = new Hashtable();
        XmlDocument m_XmlFile = null;
        m_XmlFile = new XmlDocument();
        string FilePos = "Data/" + FileName;
        TextAsset t = Resources.Load(FilePos) as TextAsset;
        m_XmlFile.LoadXml(t.text);
        //讀取Root,並將所有子節點存入node
        XmlNodeList nodes = m_XmlFile.SelectSingleNode("Root").ChildNodes;

        foreach (XmlElement node in nodes)//NodeUnit階層
        {
            //先找到目標Unit
            string NodeID = node.GetAttribute("ID");
            string InID = UnitID.ToString();
            if (false == NodeID.Equals(InID))//如果不是正確ID跳過
                continue;
            //尋找Tag內容
            foreach (XmlElement Element in node)
            {
                if (Element.Name == TagName)
                {
                    return Element.InnerText;
                }
            }



        }
        return tempHashTable;
    }*/
}
