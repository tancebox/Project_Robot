using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateBeAttack : IAIState {

    private IAI m_AI = null;
    private StageMgr m_StageMgr = null;
    private Animator m_Animator = null;
    private int m_NowStateInt = 0;

    private GameObject m_UnitObj = null;
    private GameObject m_PlayerObj = null;

    private float m_UnitView = 40;

    public AIStateBeAttack(StageMgr StageMgr, IAI AI, int ID, Animator Animator)
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
        m_Animator.SetInteger("state", 3);
        AnimatorStateInfo AnimatorInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (!AnimatorInfo.IsName("BeAttack"))
        {
            //Debug.Log("Still Idle");
            return;
        }
    }

    void CheckState()
    {
        //收到受擊訊號
        /*if (true == m_BeAttackSignal)
        {
            m_BeAttackSignal = false;
            m_State = (int)EnumMgr.UNIT_STATE.BE_ATTACK;
            return;
        }*/
        //撥放完受擊動作回到Idle
        AnimatorStateInfo AnimatorInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (AnimatorInfo.normalizedTime >= 0.9f)
        {
            m_AI.SetState((int)EnumMgr.UNIT_STATE.IDLE);
            Reset();
        }
    }

    public override void Start()
    {
        //旋轉至面對玩家
        ObjFuntion.TurnToObj(m_UnitObj, m_PlayerObj, false);
        m_StartDone = true;
    }
}
