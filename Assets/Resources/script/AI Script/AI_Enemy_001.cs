using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy_001 : IAI
    {
    private StageMgr m_StageMgr = null;
    private Animator m_Animator = null;

    //技能相關
    private SkillEnemy m_SkillEnemy = null;
    private int m_SkillDelayStep = 0;//暫時用來讓技能不要連續發射的參數

    //狀態相關
    private int m_State = (int)EnumMgr.UNIT_STATE.IDLE; //1:Idle 2:Run 3.BeAttack 5:Skill
    private bool m_IsAttacking = false;
    private bool m_BeAttackSignal = false;//受擊訊號
    private float m_UnitView = 40;

    //狀態機專用狀態們
    private IAIState m_StateIdle = null;
    private IAIState m_StateMove = null;
    private IAIState m_StateBeAttack = null;
    private IAIState m_StateSkill = null;
    private IAIState m_StateNow = null;

    public AI_Enemy_001(GameObject UnitObj, StageMgr StageMgr):base()
    {
        init(UnitObj, StageMgr);
    }

    void init(GameObject Unit, StageMgr StageMgr)
    {
        m_UnitObj = Unit;
        m_PlayerObj = StageMgr.GetPlayerObj();
        m_Animator = Unit.GetComponentInChildren<Animator>();
        m_StateIdle = new AIStateIdle(StageMgr, this, (int)EnumMgr.UNIT_STATE.IDLE, m_Animator);
        m_StateMove = new AIStateMove(StageMgr, this, (int)EnumMgr.UNIT_STATE.MOVE, m_Animator);
        m_StateBeAttack = new AIStateBeAttack(StageMgr, this, (int)EnumMgr.UNIT_STATE.BE_ATTACK, m_Animator);
        m_StateSkill = new AIStateSkill(StageMgr, this, (int)EnumMgr.UNIT_STATE.SKILL, m_Animator);

        m_StateNow = m_StateIdle;//將目前狀態設定為Idle
    }

    public override void Update()
    {
        m_StateNow.Update();
    }

    //由Mgr通知單位受攻擊
    public override void BeAttack(Vector3 Forward)
    {
        m_StateNow.ReceiveBeAttackSignal();
    }

    //
    //由StageMgr=>EnemyUnit=>這邊(考慮要不要跳過StageMgr由單位呼叫)
    public override void SkillEnd()//攻擊結束
    {
        if (m_StateNow.Equals(m_StateSkill))
            m_StateNow.End();
    }

    //切換State
    public override void SetState(int NewStateID)
    {
        if((int)EnumMgr.UNIT_STATE.MOVE == NewStateID)
            m_StateNow = m_StateMove;
        else if ((int)EnumMgr.UNIT_STATE.IDLE == NewStateID)
            m_StateNow = m_StateIdle;
        else if ((int)EnumMgr.UNIT_STATE.BE_ATTACK == NewStateID)
            m_StateNow = m_StateBeAttack;
        else if ((int)EnumMgr.UNIT_STATE.SKILL == NewStateID)
            m_StateNow = m_StateSkill;
    }

}
