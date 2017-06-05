using UnityEngine;
using System.Collections;

public class StagePlayerAction {
    private StageMgr m_StageMgr = null;
    private GameObject m_Player = null;
    private StagePlayer m_StagePlayer = null;
    private GameObject m_PlayerModel = null;
    private Animator m_Animator = null;
    private Vector3 PlayerDir;

    //技能相關
    private SkillPlayer m_SkillPlayer = null;
    private int NowSkillID = 0;
    private int m_SkillStep = 0;

    //狀態相關
    private int m_PlayerState = 1; //1:Idle 2:Walk
    private bool m_IsMoving = false;
    private bool m_IsAttacking = false;


    public StagePlayerAction(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
        m_Player = StagePlayer.Instance.GetPlayerObj();
        m_PlayerModel = GameObject.Find("PlayerModel");
        m_Animator = m_PlayerModel.GetComponent<Animator>();
        m_Animator.applyRootMotion = false;
        //技能相關
        m_SkillPlayer = SkillPlayer.Instance;

        PlayerDir = new Vector3(0, 0, 1);
    }

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	public void Update ()
    {
        if (true == m_IsAttacking)
        {
            CheckSkill();
        }
    }
    //移動
    public void MovePlayer(Vector3 Dir)
    {
        Vector3 zeroVector = new Vector3(0, 0, 0);
        Vector3 ZVector = new Vector3(0, 0, 1);

        if (true == m_IsAttacking)
        {
            return;
        }

        if (Dir.x>0.01 || Dir.z>0.01 || Dir.x < -0.01 || Dir.z <-0.01)
        {
            //Debug.Log("Action X:" + Dir.x.ToString() + " Z:" + Dir.z.ToString());
            m_Player.transform.Translate(Dir, Space.World);
            m_Animator.SetInteger("state", 2);
            m_IsMoving = true;
        }
        else if(Dir.x< 0.01 && Dir.z <0.01 && Dir.x > -0.01 && Dir.z > -0.01)
        {
            m_IsMoving = false;
            //Debug.Log("Call Check Idle");
            checkIdle();
            
        }

        if (Dir.x > 0.01 || Dir.z > 0.01 || Dir.x < -0.01 || Dir.z < -0.01)
        {
            float angle = Vector3.Angle(ZVector, Dir);
            if (Dir.x < 0)
                angle = angle * -1;
            Quaternion quate = Quaternion.identity;
            quate.eulerAngles = new Vector3(0, angle, 0); // 表示設置x軸方向旋轉了angle度
            //最後再把quate付給你要操作的Gameobject：
            m_Player.transform.rotation = quate;
        }


    }

    //施展技能
    public void PlaySkill(int SkillSlot)
    {
        Debug.Log("PlaySkill");
        
        //下面這段改為由Skill讀取表演資料

        int SkillAniID = 0;
        SkillAniID = m_SkillPlayer.getSkillAniID(SkillSlot);//讀取技能Animation對應編號
        Debug.Log("Ani ID:" + SkillAniID.ToString());
        Debug.Log("Skill Name:" + m_SkillPlayer.getSkillName(SkillSlot));
        m_Animator.SetInteger("state", SkillAniID);
        m_SkillStep = 0;
        NowSkillID = SkillSlot;
        m_IsAttacking = true;

    }
    //技能施展中
    public void CheckSkill()
    {
        NormalAttackProcess(NowSkillID);
        
    }

    private bool checkIdle()
    {
        if (true == m_IsMoving)//檢查是否為移動狀態
        {
            return false;
        }


        if (true == m_IsAttacking)//檢查是否為攻擊狀態
        {
            return false;
        }

        //Debug.Log("Check Idle 1: isAttacking=" + m_IsAttacking.ToString());
        m_Animator.SetInteger("state", 1);
        m_PlayerState = 1;
        return true;
    }

    public void SetPlayerDir(Vector3 Dir)
    {
        GameObject playerObj = StagePlayer.Instance.GetPlayerObj();
    }
    //暫時寫在這邊的普攻流程
    public void NormalAttackProcess(int SkillID)
    {
        AnimatorStateInfo AnimatorInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (AnimatorInfo.normalizedTime >= 0.5f)
        {
            m_IsAttacking = false;
            //Debug.Log("Checking OK:" + AnimatorInfo.normalizedTime.ToString() + " isAttacking =" + m_IsAttacking.ToString() + " Stete: " + m_Animator.GetInteger("state"));
            checkIdle();
        }
        if (m_SkillStep == m_SkillPlayer.getAttackPoint(SkillID))
        {
            CheckAttackRange(m_SkillPlayer.GetAttackRangeFar(SkillID));
            Debug.Log("attack");
        }
        m_SkillStep++;
        //else
        //Debug.Log("Checking:" + AnimatorInfo.normalizedTime.ToString() + " isAttacking =" + m_IsAttacking.ToString() + " Stete: " + m_Animator.GetInteger("state"));


        //m_Animator.GetAnimatorTransitionInfo(1);
    }
    //暫時寫在這邊的普攻攻擊判定
    public void CheckAttackRange(int AttackRange)
    {
        GameObject[] nearEnemys;
        nearEnemys = GameObject.FindGameObjectsWithTag("EnemyUnit");

        foreach (GameObject Enemy in nearEnemys)
        {
            //距離
            Vector3 diff = Enemy.transform.position - m_Player.transform.position;
            float curDistance = Vector3.Distance(Enemy.transform.position, m_Player.transform.position);
            //方向與角度
            Vector3 forward = m_Player.transform.TransformDirection(Vector3.forward);

            Vector3 norVec = m_Player.transform.rotation * Vector3.forward * 5;//此处*5只是为了画线更清楚,可以不要
            Vector3 temVec = Enemy.transform.position - m_Player.transform.position;
            Debug.DrawLine(m_Player.transform.position, norVec, Color.red);//画出技能释放者面对的方向向量
            Debug.DrawLine(m_Player.transform.position, Enemy.transform.position, Color.green);//画出技能释放者与目标点的连线
            float jiajiao = Mathf.Acos(Vector3.Dot(norVec.normalized, temVec.normalized)) * Mathf.Rad2Deg;//计算两个向量间的夹角
            //結果
            if (AttackRange >= curDistance && jiajiao < 30)
            {
                Debug.Log("Enemy In Range:" + curDistance.ToString());
                m_StageMgr.MgrAttackEnemy(Enemy, forward);
            }
        }

        
    }
}