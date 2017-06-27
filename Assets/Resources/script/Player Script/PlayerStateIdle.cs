using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : IPlayerState
{
    private StageMgr m_StageMgr = null;
    private StagePlayerAction m_StagePlayerAction = null;
    private Animator m_Animator = null;
    private int m_NowStateInt = 0;

    //private bool m_BeAttackSignal = false;
    private GameObject m_PlayerObj = null;

    public PlayerStateIdle(StageMgr StageMgr, StagePlayerAction StagePlayerAction, int StateID, Animator Animator)
    {
        m_StageMgr = StageMgr;
        m_StagePlayerAction = StagePlayerAction;
        m_NowStateInt = StateID;
        m_Animator = Animator;

        //m_PlayerObj = m_AI.GetPlayerObj();
    }

    public override void Update()
    {
        CheckState();
        m_Animator.SetInteger("state", 1);
    }

    void CheckState()
    {
        //收到受擊訊號
        /*if (true == m_BeAttackSignal)
        {
            m_BeAttackSignal = false;
            //m_AI.SetState((int)EnumMgr.UNIT_STATE.BE_ATTACK);
            return;
        }*/
        //檢查攻擊訊號
        if (true == m_StagePlayerAction.m_InputAttacking)
        {
            m_StagePlayerAction.SetState(m_StagePlayerAction.m_PlayerStateSkill);
        }
        //檢查移動訊號
        if (true == m_StagePlayerAction.m_InputMoving)
        {
            m_StagePlayerAction.SetState(m_StagePlayerAction.m_PlayerStateMove);
        }

    }
}
