using UnityEngine;
using System.Collections;
using System;


public class WorldUnit {
    //靜態資訊
    private string m_Name = null;

    //動態資訊

    public WorldUnit(int UnitID)
    {
        LoadWorldInfo(UnitID);
    }

    public void LoadWorldInfo(int UnitID)
    {
        m_Name = XmlTool.Instance.LoadXmlFileAttr<string> ("DATA_WORLD_UNIT", "Unit", "Name", UnitID);
    }
    //取得世界名稱
    public string GetUnitName()
    {
        return m_Name;
    }

}
