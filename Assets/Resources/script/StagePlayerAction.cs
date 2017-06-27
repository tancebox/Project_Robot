using UnityEngine;
using System.Collections;

public class StagePlayerAction {
    private StageMgr m_StageMgr = null;
    public GameObject m_PlayerObj = null;
    private StagePlayer m_StagePlayer = null;
    private GameObject m_PlayerModel = null;
    private Animator m_Animator = null;

    //技能相關
    private SkillPlayer m_SkillPlayer = null;
    public int m_NowSkillID = 0;
    private int m_SkillStep = 0;

    //移動相關
    public Vector3 m_InputDir = new Vector3(0, 0, 0);
    public float m_Speed = 1.5f;

    //狀態相關
    private int m_State = 0; //1:Idle 2:Move 3.BeAttack 5.Skill
    public bool m_InputMoving = false;//目前有移動輸入進行中
    public bool m_InputAttacking = false;//目前有攻擊輸入進行中
    public bool m_IsAttacking = false;//目前正在進行攻擊中

    private IPlayerState m_NowState = null;
    public IPlayerState m_PlayerStateIdle = null;
    public IPlayerState m_PlayerStateMove = null;
    public IPlayerState m_PlayerStateSkill = null;


    public StagePlayerAction(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
        m_PlayerObj = m_StageMgr.GetPlayerObj();
        m_PlayerModel = GameObject.Find("PlayerModel");
        m_Animator = m_PlayerModel.GetComponent<Animator>();
        m_Animator.applyRootMotion = false;
        //技能相關
        m_SkillPlayer = m_StageMgr.GetPlayerObj().GetComponent<StagePlayer>().GetSkillPlayer();
        //狀態相關
        m_PlayerStateIdle = new PlayerStateIdle(StageMgr, this, 1, m_Animator);
        m_PlayerStateMove = new PlayerStateMove(StageMgr, this, 2, m_Animator);
        m_PlayerStateSkill = new PlayerStateSkill(StageMgr, this, 5, m_Animator);
        SetState(m_PlayerStateIdle);

    }

	void Start ()
    {
        m_State = 1;
    }
	
	public void Update ()
    {
        m_NowState.Update();
    }
    
    //收到移動輸入
    public void ReceiveMoveInput(Vector3 Dir, bool isInput)
    {
        //設定方向與狀態參數
        if (true == isInput)
        {
            m_InputDir = Dir;
            m_InputMoving = true;
        }
        else
            m_InputMoving = false;

    }

    //收到技能輸入(由StageMgr呼叫)
    public void ReceiveSkillInput(int SkillSlot)
    {
        //設定
        m_InputAttacking = true;

        //下面這段改為由Skill讀取表演資料

        int SkillAniID = 0;
        SkillAniID = m_StageMgr.GetPlayerObj().GetComponent<StagePlayer>().GetSkillPlayer().getSkillAniID(SkillSlot);//讀取技能Animation對應編號
        m_Animator.SetInteger("state", SkillAniID);
        m_SkillStep = 0;
        m_NowSkillID = SkillSlot;
        

    }

    //由StageMgr設定
    public void SetAttr(string type, bool value)
    {
        if ("IsAttacking" == type)
        {
            m_IsAttacking = value;
        }
    }
    //設定State
    public void SetState(IPlayerState NewState)
    {
        m_NowState = NewState;
        Debug.Log("Set State:" + NewState.ToString());
    }

}