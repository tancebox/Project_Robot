using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSkill : IPlayerState
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

    //此類型獨有參數
    private int m_SkillStep = 0;
    private int m_NowSkillID = 0;

    public PlayerStateSkill(StageMgr StageMgr, StagePlayerAction StagePlayerAction, int StateID, Animator Animator)
    {
        m_StageMgr = StageMgr;
        m_StagePlayerAction = StagePlayerAction;
        m_NowStateInt = StateID;
        m_Animator = Animator;
        m_PlayerObj = m_StagePlayerAction.m_PlayerObj;

        m_StartDone = false;

        //m_PlayerObj = m_AI.GetPlayerObj();
    }

    public override void Update()
    {
        if (false == m_StartDone)
        {
            Start();
            return;
        }
        CheckState();
        if ("NormalAttack" == m_StageMgr.GetPlayerObj().GetComponent<StagePlayer>().GetSkillPlayer().getSkillType(m_NowSkillID))
        {
            SkillPlayerNormalAttack.Instance.SkillUpdate(m_PlayerObj, m_Animator, m_NowSkillID, m_SkillStep);
        }
        if ("Shoot" == m_StageMgr.GetPlayerObj().GetComponent<StagePlayer>().GetSkillPlayer().getSkillType(m_NowSkillID))
        {
            SkillPlayerShoot.Instance.SkillUpdate(m_PlayerObj, m_Animator, m_NowSkillID, m_SkillStep);
        }
        m_SkillStep++;

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
        //檢查技能撥放完畢
        if (false == m_StagePlayerAction.m_IsAttacking)
        {
            End();
        }
        //檢查移動訊號
        if(false == m_StagePlayerAction.m_InputMoving)
        {
            //m_StagePlayerAction.SetState(m_StagePlayerAction.m_PlayerStateIdle);
        }

    }

    public override void Start()
    {
        Debug.Log("Skill Start player");

        int SkillAniID = 0;
        m_StagePlayerAction.m_InputAttacking = false;
        m_StagePlayerAction.m_IsAttacking = true;
        m_NowSkillID = m_StagePlayerAction.m_NowSkillID;
        SkillAniID = m_StageMgr.GetPlayerObj().GetComponent<StagePlayer>().GetSkillPlayer().getSkillAniID(m_NowSkillID);//讀取技能Animation對應編號
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
        m_StagePlayerAction.SetState(m_StagePlayerAction.m_PlayerStateIdle);
        Reset();
    }
}
