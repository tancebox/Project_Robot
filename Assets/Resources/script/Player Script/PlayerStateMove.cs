using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMove : IPlayerState
{
    private StageMgr m_StageMgr = null;
    private StagePlayerAction m_StagePlayerAction = null;
    private Animator m_Animator = null;
    private int m_NowStateInt = 0;

    //private bool m_BeAttackSignal = false;
    private GameObject m_PlayerObj = null;
    //移動相關
    public Vector3 m_InputDir = new Vector3(0, 0, 0);
    public float m_Speed = 1.5f;

    public PlayerStateMove(StageMgr StageMgr, StagePlayerAction StagePlayerAction, int StateID, Animator Animator)
    {
        m_StageMgr = StageMgr;
        m_StagePlayerAction = StagePlayerAction;
        m_NowStateInt = StateID;
        m_Animator = Animator;
        m_PlayerObj = m_StagePlayerAction.m_PlayerObj;

        //m_PlayerObj = m_AI.GetPlayerObj();
    }

    public override void Update()
    {
        CheckState();
        Debug.Log("Update in move");
        m_Animator.SetInteger("state", 2);

        //位移
        m_InputDir = m_StagePlayerAction.m_InputDir;

        Vector3 MoveValue = new Vector3(m_InputDir.x * m_Speed, m_InputDir.y * m_Speed, m_InputDir.z * m_Speed);
        m_PlayerObj.transform.Translate(MoveValue, Space.World);
        m_Animator.SetInteger("state", 2);
        //設定玩家方向
        ObjFuntion.TurnToDir(m_PlayerObj, m_InputDir, false);
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
        //檢查移動訊號(沒有移動時)
        if (false == m_StagePlayerAction.m_InputMoving)
        {
            m_StagePlayerAction.SetState(m_StagePlayerAction.m_PlayerStateIdle);
        }

    }
}
