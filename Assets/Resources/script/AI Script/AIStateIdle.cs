using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateIdle : IAIState{

    private IAI m_AI = null;
    private StageMgr m_StageMgr = null;
    private Animator m_Animator = null;
    private int m_NowStateInt = 0;

    //private bool m_BeAttackSignal = false;

    private GameObject m_UnitObj = null;
    private GameObject m_PlayerObj = null;

    private float m_UnitView = 40;

    public AIStateIdle(StageMgr StageMgr, IAI AI, int ID, Animator Animator)
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
        //Debug.Log("Update in Idle");
        CheckState();
        m_Animator.SetInteger("state", 1);
    }

    void CheckState()
    {
        //收到受擊訊號
        if (true == m_BeAttackSignal)
        {
            m_BeAttackSignal = false;
            m_AI.SetState((int)EnumMgr.UNIT_STATE.BE_ATTACK);
            return;
        }
        //視線內出現玩家
        if (true == ObjFuntion.CheckTargetInDis(m_UnitObj, m_PlayerObj, m_UnitView))
        {
            m_AI.SetState((int)EnumMgr.UNIT_STATE.MOVE);
        }
    }
}
