using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy_001
    {
    private StageMgr m_StageMgr = null;
    private GameObject m_PlayerObj = null;
    private Animator m_Animator = null;
    private GameObject m_UnitObj = null;

    //技能相關
    private SkillEnemy m_SkillEnemy = null;
    private int m_SkillStep = 0;

    //狀態相關
    private int m_State = 1; //1:Idle 2:Run 3.BeAttack 5:Skill
    private bool m_IsMoving = false;
    private bool m_IsAttacking = false;
    private bool m_BeAttackSignal = false;//受擊訊號
    private bool m_BeAttacking = false;//受擊表演中(也許用狀態替代)
    private float m_UnitView = 40;

    public AI_Enemy_001(GameObject UnitObj, StageMgr StageMgr)
    {
        Debug.Log("Creat");
        init(UnitObj, StageMgr);
    }

    // Use this for initialization
    void Start()
    {

    }

    

    void init(GameObject Unit, StageMgr StageMgr)
    {
        m_UnitObj = Unit;
        m_PlayerObj = StageMgr.GetPlayerObj();
        //m_SkillEnemy = new SkillEnemy(m_StageMgr);
        m_Animator = Unit.GetComponentInChildren<Animator>();
        m_State = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        //判斷
        CheckState();
        //執行
        switch (m_State)
        {
            case 1:
                IdleUpdate();
                break;
            case 2:
                RunUpdate();
                break;
            case 3:
                BeAttackUpdate();
                break;
            case 5:
                SkillUpdate();
                break;
        }
    }

    void CheckState()//之後拆成各State獨立判斷函式
    {
        if(1 == m_State)//待機時的Check
        {
            //收到受擊訊號
            if (true == m_BeAttackSignal)
            {
                m_BeAttackSignal = false;
                m_State = 3;
                return;
            }
            //視線內出現玩家
            if (true == ObjFuntion.CheckTargetInDis(m_UnitObj, m_PlayerObj, m_UnitView))
            {
                m_State = 2;
            }
        }

        if (2 == m_State)//移動時的Check
        {
            if (true == m_BeAttackSignal)
            {
                m_BeAttackSignal = false;
                m_State = 3;
            }
            //玩家進入攻擊距離
            float AttackDis = 20;
            if (true == ObjFuntion.CheckTargetInDis(m_UnitObj, m_PlayerObj, AttackDis))
            {
                SkillStart();
            }

            //玩家離開視線
            if (false == ObjFuntion.CheckTargetInDis(m_UnitObj, m_PlayerObj, m_UnitView))
            {
                m_State = 1;
                m_Animator.SetInteger("state", 1);
            }
        }

        if (3 == m_State)//受擊時的Check
        {
            if (true == m_BeAttackSignal)
            {
                m_BeAttackSignal = false;
                m_State = 3;
            }
        }

        if (5 == m_State)//攻擊時的Check
        {
            //收到受擊訊號
            if (true == m_BeAttackSignal)
            {
                m_BeAttackSignal = false;
                m_State = 3;
                m_IsAttacking = false;
                return;
            }
            if (true == m_IsAttacking)
            {
                SkillUpdate();
            }
            else
            {
                m_State = 2;
                //m_Animator.SetInteger("state", 1);
            }
        }

    }

    private void IdleUpdate()
    {
        //檢查視線範圍內是否出現玩家
    }
    private void RunUpdate()
    {
        //檢查玩家是否在攻擊範圍內

        //取得玩家方向並往玩家移動
        m_Animator.SetInteger("state", 2);
        Vector3 Dir = m_PlayerObj.transform.position - m_UnitObj.transform.position;
        //轉身
        ObjFuntion.TurnToObj(m_UnitObj, m_PlayerObj, false);
        //移動
        m_UnitObj.transform.Translate(Dir.x*0.01f , Dir.y*0.01f, Dir.z * 0.01f, Space.World);
    }
    private void BeAttackUpdate()
    {
        AnimatorStateInfo AnimatorInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (!AnimatorInfo.IsName("BeAttack"))
        {
            //Debug.Log("Still Idle");
            return;
        }
            
        if (AnimatorInfo.normalizedTime >= 0.9f)
        {
            m_State = 1;
            m_Animator.SetInteger("state", 1);
            Debug.Log("return idle");
        }
    }

    void SkillUpdate()
    {
        string SkillName = m_UnitObj.GetComponent<StageEnemyUnit>().GetSkillEnemy().getSkillType(0);
        if ("Shoot" == m_UnitObj.GetComponent<StageEnemyUnit>().GetSkillEnemy().getSkillType(0))
        {
            SkillEnemyShoot.Instance.SkillUpdate(m_UnitObj, m_Animator, 0, m_SkillStep);
        }
        m_SkillStep += 1;
    }

    void SkillStart()
    {
        //設定
        //m_InputAttacking = true;

        //下面這段改為由Skill讀取表演資料

        int SkillAniID = 0;
        SkillAniID = m_UnitObj.GetComponent<StageEnemyUnit>().GetSkillEnemy().getSkillAniID(0);//讀取技能Animation對應編號
        m_Animator.SetInteger("state", SkillAniID);
        m_SkillStep = 0;
        m_IsAttacking = true;
        m_State = 5;
        //m_NowSkillID = SkillSlot;
    }

    //由Mgr通知單位受攻擊
    public void BeAttack(Vector3 Forward)
    {
        //Debug.Log("AI Be Attack!");
        m_BeAttackSignal = true;
        m_Animator.SetInteger("state", 3);
        //旋轉至面對玩家
        ObjFuntion.TurnToObj(m_UnitObj, m_PlayerObj, false);
    }

    //
    //由StageMgr設定
    public void SetAIAttr(string type, bool value)
    {
        if ("IsAttacking" == type)
        {
            m_IsAttacking = value;
        }
    }

}
