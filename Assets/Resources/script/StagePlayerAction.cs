using UnityEngine;
using System.Collections;

public class StagePlayerAction {
    private StageMgr m_StageMgr = null;
    private GameObject m_Player = null;
    private StagePlayer m_StagePlayer = null;
    private GameObject m_PlayerModel = null;
    private Animator m_Animator = null;

    //技能相關
    private SkillPlayer m_SkillPlayer = null;
    private int m_NowSkillID = 0;
    private int m_SkillStep = 0;

    //移動相關
    private Vector3 m_InputDir = new Vector3(0, 0, 0);

    //狀態相關
    private int m_State = 0; //1:Idle 2:Move 3.BeAttack 5.Skill
    private bool m_InputMoving = false;//目前有移動輸入進行中
    private bool m_InputAttacking = false;//目前有攻擊輸入進行中
    private bool m_IsAttacking = false;//目前正在進行攻擊中


    public StagePlayerAction(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
        m_Player = StagePlayer.Instance.GetPlayerObj();
        m_PlayerModel = GameObject.Find("PlayerModel");
        m_Animator = m_PlayerModel.GetComponent<Animator>();
        m_Animator.applyRootMotion = false;
        //技能相關
        m_SkillPlayer = SkillPlayer.Instance;
    }

	// Use this for initialization
	void Start ()
    {
        m_State = 1;
    }
	
	// Update is called once per frame
	public void Update ()
    {
        CheckState();
        //執行
        switch (m_State)
        {
            case 1://待機
                IdleUpdate();
                break;
            case 2://移動
                MoveUpdate();
                break;
            case 3://受擊
                BeAttackUpdate();
                break;
            case 5://攻擊
                SkillUpdate();
                break;
        }
    }
    void CheckState()
    {
        //接收到技能輸入，切換為技能狀態
        if (true == m_InputAttacking)
        {
            m_InputAttacking = false;
            m_IsAttacking = true;
            m_State = 5;
            Debug.Log("Start Skill");
            return;
        }
        //如果技能狀態尚未結束，維持技能狀態
        if (true == m_IsAttacking)
        {
            m_State = 5;
            return;
        }

        //若非技能狀態時，接收到移動輸入，切換或維持移動狀態
        if (true == m_InputMoving)
        {
            m_State = 2;
            return;
        }
        //若無任何輸入，檢查待機
        if (false == m_InputAttacking && false == m_InputMoving && false == m_IsAttacking)
        {
            m_Animator.SetInteger("state", 1);
            m_State = 1;
            return;
        }
        return;
    }
    //待機
    void IdleUpdate()
    {
    }
    //移動
    void MoveUpdate()
    {
        //位移
        m_Player.transform.Translate(m_InputDir, Space.World);
        m_Animator.SetInteger("state", 2);
        //玩家方向
        Vector3 ZVector = new Vector3(0, 0, 1);
        float angle = Vector3.Angle(ZVector, m_InputDir);
        if (m_InputDir.x < 0)
            angle = angle * -1;
        Quaternion quate = Quaternion.identity;
        quate.eulerAngles = new Vector3(0, angle, 0); // 表示設置x軸方向旋轉了angle度
        //最後再把quate付給你要操作的Gameobject：
        m_Player.transform.rotation = quate;
    }
    //受擊
    void BeAttackUpdate()
    {
    }
    //技能施展
    public void SkillUpdate()
    {
        if ("NormalAttack" == SkillPlayer.Instance.getSkillType(m_NowSkillID))
        {
            SkillPlayerNormalAttack.Instance.SkillUpdate(m_Player, m_SkillPlayer, m_Animator, m_NowSkillID, m_SkillStep);
        }
        m_SkillStep++;
    }
    
    //收到移動
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

    //收到技能(由StageMgr呼叫)
    public void ReceiveSkillInput(int SkillSlot)
    {
        //設定
        m_InputAttacking = true;

        //下面這段改為由Skill讀取表演資料

        int SkillAniID = 0;
        SkillAniID = m_SkillPlayer.getSkillAniID(SkillSlot);//讀取技能Animation對應編號
        m_Animator.SetInteger("state", SkillAniID);
        m_SkillStep = 0;
        m_NowSkillID = SkillSlot;
        

    }

    //由StageMgr設定
    public void MgrSetAttr(string type, bool value)
    {
        if ("IsAttacking" == type)
        {
            m_IsAttacking = value;
        }
    }
}