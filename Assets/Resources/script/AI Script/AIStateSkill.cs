using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateSkill : IAIState
{
    private IAI m_AI = null;
    private StageMgr m_StageMgr = null;
    private Animator m_Animator = null;
    private int m_NowStateInt = 0;

    private GameObject m_UnitObj = null;
    private GameObject m_PlayerObj = null;

    private float m_UnitView = 40;

    //此類型獨有參數
    private int m_SkillStep = 0;

    public AIStateSkill(StageMgr StageMgr, IAI AI, int ID, Animator Animator)
    {
        m_AI = AI;
        m_StageMgr = StageMgr;
        m_NowStateInt = ID;
        m_Animator = Animator;

        m_UnitObj = m_AI.GetUnitObj();
        m_PlayerObj = m_AI.GetPlayerObj();
    }

    public override void Update()
    {
        if (false == m_StartDone)
        {
            Start();
            return;
        }
        CheckState();
        //技能更新
        string SkillName = m_UnitObj.GetComponent<StageEnemyUnit>().GetSkillEnemy().getSkillType(0);
        if ("Shoot" == SkillName)
        {
            SkillEnemyShoot.Instance.SkillUpdate(m_UnitObj, m_Animator, 0, m_SkillStep);
        }
        m_SkillStep += 1;
    }

    void CheckState()
    {
        //收到受擊訊號
        if (true == m_BeAttackSignal)
        {
            m_BeAttackSignal = false;
            m_AI.SetState((int)EnumMgr.UNIT_STATE.BE_ATTACK);
            Reset();//將技能相關參數歸零
            return;
        }
        
    }

    public override void Start()
    {
        int SkillAniID = 0;
        SkillAniID = m_UnitObj.GetComponent<StageEnemyUnit>().GetSkillEnemy().getSkillAniID(0);//讀取技能Animation對應編號
        m_Animator.SetInteger("state", SkillAniID);
        m_SkillStep = 0;
        m_StartDone = true;
    }

    public override void Reset()
    {
        m_StartDone = false;
        m_SkillStep = 0;
    }
    //技能播放結束
    public override void End()
    {
        m_AI.SetState((int)EnumMgr.UNIT_STATE.IDLE);
        Reset();
    }


}
