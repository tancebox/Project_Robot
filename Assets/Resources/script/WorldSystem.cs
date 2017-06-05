using UnityEngine;
using System.Collections;

using System;
using System.Linq;
using System.Collections.Generic;

public class WorldSystem{

    private int m_NowWorld;
    private int m_WorldAmount;
    private WorldUnit[] WorldObj = null;

    //Singloton
    private static WorldSystem _instance = null;
    public static WorldSystem Instance
    {
        get
        {
            if (_instance == null)
                _instance = new WorldSystem();
            return _instance;
        }
    }

    public WorldSystem() {
        
    }

    public void init() {
        m_NowWorld = GetNowWorldFromSaveData();//由存檔取得目前世界
        m_WorldAmount = Int32.Parse(XmlTool.Instance.LoadXmlFile("SAVE_WORLD", "Save", "WorldAmount", 0));//由存檔取得世界數量
        Debug.Log("WorldAmount" + m_WorldAmount.ToString());
        //建造各世界
        WorldObj = new WorldUnit[m_WorldAmount];
        for (int i = 0; i < m_WorldAmount; i++)
        {
            WorldObj[i] = new WorldUnit(i);
        }
    }
    //設定WorldSystem目前的m_NowWorld
    public void SetNowWorld(int NowWorld)
    {
        m_NowWorld = NowWorld;
        //補上寫入存檔
    }
    //取得WorldSystem目前的m_NowWorld
    public int GetNowWorld() {
        return m_NowWorld;
    }
    //取得目前世界的名稱
    public string GetNowWorldName()
    {
        string NowWorldName = WorldObj[m_NowWorld].GetUnitName();
        return NowWorldName;
    }
    //由存檔設定目前所在WORLD
    public int GetNowWorldFromSaveData()
    {
        int NoeWorld = -1;
        NoeWorld = Int32.Parse(XmlTool.Instance.LoadXmlFile("SAVE_WORLD", "Save", "NowWorld",0));
        return NoeWorld;
    }
}
