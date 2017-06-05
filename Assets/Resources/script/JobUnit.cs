using UnityEngine;
using System.Collections;

using System;
using System.Linq;
using System.Collections.Generic;

public class JobUnit{

	private string m_Name = null;
    private int m_Lv;

    private Hashtable Attrs = null;

    public JobUnit(int UnitID) {
        LoadJobInfo(UnitID);
    }
    
    public void LoadJobInfo(int UnitID)
    {
        m_Name = XmlTool.Instance.LoadXmlFile("Job", "Unit", "Name", UnitID);
        m_Lv = Int32.Parse(XmlTool.Instance.LoadXmlFile("SAVE_JOB", "Job", "Lv", UnitID));
    }
    
    public string GetJobUnitName()
    {
        return m_Name;
    }
    public int GetJobUnitLv()
    {
        return m_Lv;
    }
}
