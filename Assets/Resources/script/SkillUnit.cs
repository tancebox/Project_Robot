using UnityEngine;
using System.Collections;

using System;
using System.Linq;
using System.Collections.Generic;

public class SkillUnit
{
    private int m_ID;
    private string m_Name = null;
    private int m_Lv;
    private string m_SkillType;
    private int m_AniID;
    private int m_AttackPoint;
    private int m_ContinuePoint;
    private int m_EndPoint;
    //戰鬥參數
    private int m_AttackRangeFar;

    public SkillUnit(int UnitID)
    {
        LoadSkillInfo(UnitID);
    }

    public void LoadSkillInfo(int UnitID)
    {
        m_ID = UnitID;
        m_Name = XmlTool.Instance.LoadXmlFile("Skill", "Unit", "Name", UnitID);
        m_Lv = Int32.Parse(XmlTool.Instance.LoadXmlFile("SAVE_SKILL", "Job", "Lv", UnitID));
        m_SkillType = XmlTool.Instance.LoadXmlFile("SKILL", "Unit", "SkillType", UnitID);
        m_AniID = Int32.Parse(XmlTool.Instance.LoadXmlFile("Skill", "Unit", "Animation", UnitID));
        m_AttackPoint = Int32.Parse(XmlTool.Instance.LoadXmlFile("Skill", "Unit", "AttackPoint", UnitID));
        m_ContinuePoint = Int32.Parse(XmlTool.Instance.LoadXmlFile("Skill", "Unit", "ContinuePoint", UnitID));
        m_EndPoint = Int32.Parse(XmlTool.Instance.LoadXmlFile("Skill", "Unit", "EndPoint", UnitID));
        m_AttackRangeFar = Int32.Parse(XmlTool.Instance.LoadXmlFile("Skill", "Unit", "AttackRangeFar", UnitID));
    }

    public string GetSkillUnitName()
    {
        return m_Name;
    }
    public int GetSkillUnitLv()
    {
        return m_Lv;
    }
    public string GetSkillUnitType()
    {
        return m_SkillType;
    }
    public int GetAniID()
    {
        return m_AniID;
    }
    public int GetSkillID()
    {
        return m_ID;
    }
    public int GetAttackPoint()
    {
        return m_AttackPoint;
    }
    public int GetEndPoint()
    {
        return m_EndPoint;
    }
    public int GetAttackRangeFar()
    {
        return m_AttackRangeFar;
    }
}
