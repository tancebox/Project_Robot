using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPlayerNormalAttack {

    private StageMgr m_StageMgr = null;

    private static SkillPlayerNormalAttack _instance;
    public static SkillPlayerNormalAttack Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SkillPlayerNormalAttack();
            return _instance;
        }
    }

    public SkillPlayerNormalAttack() {
    
    }

    public void init(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckAttack(GameObject Attacker,int SkillID)
    {

    }
    //技能更新
    public void SkillUpdate(GameObject Attacker, SkillPlayer SkillPlayer, Animator Animator, int SkillID, int SkillStep)
    {
        AnimatorStateInfo AnimatorInfo = Animator.GetCurrentAnimatorStateInfo(0);
        if (AnimatorInfo.IsName("Walk"))
        {
            Debug.Log("Still Walk");
            return;
        }
        else if (SkillStep == SkillPlayer.getAttackPoint(SkillID) + 20)
        {
            m_StageMgr.SetPlayerActionAttr("IsAttacking", false);
            //m_IsAttacking = false;
        }
        if (SkillStep == SkillPlayer.getAttackPoint(SkillID))//攻擊點
        {
            CheckAttackRange(SkillPlayer.GetAttackRangeFar(SkillID),Attacker);
        }
    }
    //取得攻擊對象
    public void CheckAttackRange(int AttackRange, GameObject Player)
    {
        GameObject[] nearEnemys;
        nearEnemys = GameObject.FindGameObjectsWithTag("EnemyUnit");

        foreach (GameObject Enemy in nearEnemys)
        {
            //距離
            Vector3 diff = Enemy.transform.position - Player.transform.position;
            float curDistance = Vector3.Distance(Enemy.transform.position, Player.transform.position);
            //方向與角度
            Vector3 forward = Player.transform.TransformDirection(Vector3.forward);

            Vector3 norVec = Player.transform.rotation * Vector3.forward * 5;//此处*5只是为了画线更清楚,可以不要
            Vector3 temVec = Enemy.transform.position - Player.transform.position;
            Debug.DrawLine(Player.transform.position, norVec, Color.red);//画出技能释放者面对的方向向量
            Debug.DrawLine(Player.transform.position, Enemy.transform.position, Color.green);//画出技能释放者与目标点的连线
            float Angle = Mathf.Acos(Vector3.Dot(norVec.normalized, temVec.normalized)) * Mathf.Rad2Deg;//計算夾角
            //結果
            if (AttackRange >= curDistance && Angle < 50)
            {
                Debug.Log("Enemy In Range:" + curDistance.ToString());
                m_StageMgr.MgrAttackEnemy(Enemy, forward);
            }
        }


    }
}
