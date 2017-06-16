using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMove : IAIState{

    private IAI m_AI = null;
    private StageMgr m_StageMgr = null;
    private Animator m_Animator = null;
    private int m_NowStateInt = 0;

    private GameObject m_UnitObj = null;
    private GameObject m_PlayerObj = null;

    private float m_UnitView = 40;

    public AIStateMove(StageMgr StageMgr, IAI AI, int ID, Animator Animator)
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
        CheckState();
        //取得玩家方向並往玩家移動
        m_Animator.SetInteger("state", 2);
        Vector3 Dir = m_PlayerObj.transform.position - m_UnitObj.transform.position;
        //轉身
        ObjFuntion.TurnToObj(m_UnitObj, m_PlayerObj, false);
        //移動
        m_UnitObj.transform.Translate(Dir.x * 0.01f, Dir.y * 0.01f, Dir.z * 0.01f, Space.World);
    }

    void CheckState()
    {
        //收到受擊訊號
        if (true == m_BeAttackSignal)
        {
            m_BeAttackSignal = false;
            m_AI.SetState((int)EnumMgr.UNIT_STATE.BE_ATTACK);
            Debug.Log("轉換到受擊狀態");
            return;
        }
        //玩家進入攻擊範圍
        float AttackDis = 20;
        if (true == ObjFuntion.CheckTargetInDis(m_UnitObj, m_PlayerObj, AttackDis))
        {
            m_AI.SetState((int)EnumMgr.UNIT_STATE.SKILL);
            return;
        }
        //玩家離開視野範圍
        if (false == ObjFuntion.CheckTargetInDis(m_UnitObj, m_PlayerObj, m_UnitView))
        {
            m_AI.SetState((int)EnumMgr.UNIT_STATE.IDLE);
            return;
        }
        
    }
}
