using UnityEngine;
using System.Collections;

public class SkillPlayer
{

    private LobbyMgr m_LobbyMgr = null;



    private SkillUnit[] SkillObj = null;

    //Singloton
    private static SkillPlayer _instance = null;
    public static SkillPlayer Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SkillPlayer();
            return _instance;
        }
    }
    
    //建構式
    public SkillPlayer()
    {
        
    }



    public void init(StageMgr StageMgr)
    {
        //初始化各類主角技能Class
        SkillPlayerNormalAttack.Instance.init(StageMgr);

        SkillObj = new SkillUnit[2];

        SkillObj[0] = new SkillUnit(0);//技能0
        SkillObj[1] = new SkillUnit(1);//技能1

    }

    public string getSkillName(int SkillID)
    {
        string SkillName = "";
        SkillName = SkillObj[SkillID].GetSkillUnitName();
        return SkillName;
    }
    public int getSkillLv(int SkillID)
    {
        int SkillLv = 0;
        SkillLv = SkillObj[SkillID].GetSkillUnitLv();
        return SkillLv;
    }
    public string getSkillType(int SkillID)//取得技能類型
    {
        string SkillType = "";
        SkillType = SkillObj[SkillID].GetSkillUnitType();
        return SkillType;
    }
    public int getSkillAniID(int SkillID)//取得動畫ID
    {
        int SkillAniID = 0;
        SkillAniID = SkillObj[SkillID].GetAniID();
        return SkillAniID;
    }

    public int getAttackPoint(int SkillID)//取得AttackPoint
    {
        int AttackPoint = 0;
        AttackPoint = SkillObj[SkillID].GetAttackPoint();
        return AttackPoint;
    }

    public int getEndPoint(int SkillID)//取得EndPoint
    {
        int EndPoint = 0;
        EndPoint = SkillObj[SkillID].GetEndPoint();
        return EndPoint;
    }

    public int GetAttackRangeFar(int SkillID)//取得EndPoint
    {
        int AttackRangeFar = 0;
        AttackRangeFar = SkillObj[SkillID].GetAttackRangeFar();
        return AttackRangeFar;
    }

}
