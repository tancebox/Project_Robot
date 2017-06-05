using UnityEngine;
using System.Collections;
using System;

public class PlayerResource {
    //貨幣類資源
    private int m_Gold = 0;
    public int Gold{
        get{ return m_Gold;}
        set{ m_Gold = value;}
    }

    public PlayerResource() {
    }

    //Singloton
    private static PlayerResource _instance = null;
    public static PlayerResource Instance
    {
        get
        {
            if (_instance == null)
                _instance = new PlayerResource();
            return _instance;
        }
    }

    public void init() {
        m_Gold = XmlTool.Instance.LoadXmlFileAttr<int>("SAVE_RESOURCE", "NumResource","Gold",0);
        Debug.Log("Gold: " + m_Gold.ToString());
    }

}
